using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 实用工具
/// </summary>
public static class Utilities {

	/// <summary> 查询场景中的第一个类型 </summary> 
	public static bool FindObject<T>(out T type) where T : UnityEngine.Object {
		T[] types = GameObject.FindObjectsOfType<T>();
		type = types.Length > 0 ? types[0] : null;
		return type != null;
	}
	/// <summary> 查询场景中的全部类型 </summary> 
	public static void FindObjects<T>(Action<T> action) where T : UnityEngine.Object {
		T[] types = GameObject.FindObjectsOfType<T>();
		for (int i = 0; i < types.Length; i++) { action?.Invoke(types[i]); }
	}

	/// <summary> 获取组件 </summary> 
	public static bool Try<T>(this Component obj, out T component) {
		if (obj == null) { component = default(T); return false; }
		return obj.TryGetComponent(out component);
	}

	/// <summary> 输入方向 转换成 目标的相对方向  </summary>
	public static Vector2 TransferDirection(Vector3 forward, Vector3 right, Vector2 inputDirection) {
		// 确保前方和右方方向在水平面上
		forward.y = 0;
		right.y = 0;

		// 归一化方向向量
		forward.Normalize();
		right.Normalize();

		// 计算移动方向
		Vector3 moveDirection = (forward * inputDirection.y + right * inputDirection.x).normalized;
		return new Vector2(moveDirection.x, moveDirection.z);
	}

	/// <summary> 头尾循环标准化索引 </summary>
	public static Data LoopIndex<Data>(this List<Data> list, int index) {
		return list[LoopIndex(index, list.Count)];
	}
	/// <summary> 头尾循环标准化索引 </summary>
	public static Data LoopIndex<Data>(this Data[] array, int index) {
		return array[LoopIndex(index, array.Length)];
	}
	/// <summary> 头尾循环标准化索引 </summary>
	public static int LoopIndex(int index, int maxIndex) {
		int i = index % maxIndex;
		return i < 0 ? i + maxIndex : i;
	}

	/// <summary> 是否平行 </summary>
	public static bool Parallel(Vector3 directionA, Vector3 directionB) {
		// 检查两个向量是否平行（叉积接近零）
		float crossMagnitude = Vector3.Cross(directionA, directionB).magnitude;
		// 0.01f 是判定平行的阈值，可以根据需要调整
		return crossMagnitude < 0.01f;
	}
	/// <summary> 向量投影法 </summary> 
	public static Vector3 Projection(Vector3 point, Vector3 aPoint, Vector3 bPoint) {
		Vector3 ac = point - aPoint;
		Vector3 p = Vector3.Project(ac, (bPoint - aPoint).normalized);
		Vector3 intersectPoint = p + aPoint;
		return intersectPoint;
	}
	/// <summary>
	/// 计算AB与CD两条线段的交点.
	/// </summary>
	/// <param name="a">A点</param>
	/// <param name="b">B点</param>
	/// <param name="c">C点</param>
	/// <param name="d">D点</param>
	/// <param name="intersectPos">AB与CD的交点</param>
	/// <returns>是否相交 true:相交 false:未相交</returns>
	public static bool TryCross(Vector3 a, Vector3 b, Vector3 c, Vector3 d, out Vector3 intersectPos) {
		intersectPos = Vector3.zero;

		Vector3 ab = b - a;
		Vector3 ca = a - c;
		Vector3 cd = d - c;

		Vector3 v1 = Vector3.Cross(ca, cd);
		// 不共面
		if (Mathf.Abs(Vector3.Dot(v1, ab)) > 1e-6) { return false; }
		// 平行
		if (Vector3.Cross(ab, cd).sqrMagnitude <= 1e-6) { return false; }

		// 快速排斥
		if (Mathf.Min(a.x, b.x) > Mathf.Max(c.x, d.x) || Mathf.Max(a.x, b.x) < Mathf.Min(c.x, d.x) ||
			Mathf.Min(a.y, b.y) > Mathf.Max(c.y, d.y) || Mathf.Max(a.y, b.y) < Mathf.Min(c.y, d.y) ||
			Mathf.Min(a.z, b.z) > Mathf.Max(c.z, d.z) || Mathf.Max(a.z, b.z) < Mathf.Min(c.z, d.z)) {
			return false;
		}

		Vector3 ad = d - a;
		Vector3 cb = b - c;
		// 跨立试验
		if (Vector3.Dot(Vector3.Cross(-ca, ab), Vector3.Cross(ab, ad)) <= 0 ||
			Vector3.Dot(Vector3.Cross(ca, cd), Vector3.Cross(cd, cb)) <= 0) {
			return false;
		}

		Vector3 v2 = Vector3.Cross(cd, ab);
		float ratio = Vector3.Dot(v1, v2) / v2.sqrMagnitude;
		intersectPos = a + ab * ratio;
		return true;
	}
	/// <summary>
	/// 计算AB与CD两条线段的交点.
	/// </summary>
	/// <param name="a">A点</param>
	/// <param name="b">B点</param>
	/// <param name="c">C点</param>
	/// <param name="d">D点</param>
	/// <param name="intersectPos">AB与CD的交点</param>
	/// <returns>是否相交 true:相交 false:未相交</returns>
	public static bool TryCrossExtend(Vector3 a, Vector3 b, Vector3 c, Vector3 d, out Vector3 intersectPos) {
		intersectPos = Vector3.zero;

		Vector3 ab = b - a;
		Vector3 ca = a - c;
		Vector3 cd = d - c;

		Vector3 v1 = Vector3.Cross(ca, cd);
		// 不共面
		if (Mathf.Abs(Vector3.Dot(v1, ab)) > 1e-6) { return false; }
		// 平行
		if (Vector3.Cross(ab, cd).sqrMagnitude <= 1e-6) { return false; }

		Vector3 v2 = Vector3.Cross(cd, ab);
		float ratio = Vector3.Dot(v1, v2) / v2.sqrMagnitude;
		intersectPos = a + ab * ratio;
		return true;
	}
}

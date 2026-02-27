using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 边界测试
/// </summary>
public class BoundsTest : MonoBehaviour {
	/// <summary>
	/// 显示类型
	/// </summary>
	public enum Type { Whole, World, Local }

	/// <summary> 显示类型 </summary>
	public Type type;
	/// <summary> 世界边界 </summary>
	public BoundsWorld boundsWorld;
	/// <summary> 本地 </summary>
	public BoundsLocal boundsLocal;

	/// <summary> 初始化 </summary>
	public void Initial() {
		boundsWorld = new BoundsWorld();
		boundsWorld.Calculate(transform);
		boundsLocal = new BoundsLocal();
		boundsLocal.Calculate(transform);
	}

	/// <summary> 在Scene视图中绘制包围盒 </summary>
	protected virtual void OnDrawGizmosSelected() {
		if (type == Type.Whole || type == Type.World) { DrawWorld(); }
		if (type == Type.Whole || type == Type.Local) { DrawLocal(); }
	}
	/// <summary> 绘制世界边界 </summary>
	private void DrawWorld() {
		if (boundsWorld == null) { Initial(); }
		Vector3 size = boundsWorld.size;
		Vector3 center = boundsWorld.center;
		Gizmos.color = Color.blue;
		Vector3 position = transform.position + center;
		Gizmos.DrawWireCube(position, size);

		DebugPosition(transform.position + center);
	}
	/// <summary> 绘制本地边界 </summary>
	private void DrawLocal() {
		if (boundsLocal == null) { Initial(); }
		Vector3 size = boundsLocal.size;
		Vector3 center = boundsLocal.center;
		Gizmos.color = Color.green;
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.DrawWireCube(center, size);
	}
	/// <summary> 显示坐标点 </summary> 
	private void DebugPosition(Vector3 position) {
		// 绘制锚点
		Debug.DrawRay(position, new Vector3(1, 0, 0), Color.red);
		Debug.DrawRay(position, new Vector3(-1, 0, 0), Color.red);

		Debug.DrawRay(position, new Vector3(0, 1, 0), Color.green);
		Debug.DrawRay(position, new Vector3(0, -1, 0), Color.green);

		Debug.DrawRay(position, new Vector3(0, 0, 1), Color.blue);
		Debug.DrawRay(position, new Vector3(0, 0, -1), Color.blue);
	}
}

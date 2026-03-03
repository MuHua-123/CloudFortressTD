using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 平铺对象 - 编辑器
/// </summary>
[CustomEditor(typeof(TilingObject))]
public class TilingObjectEditor : Editor {
	/// <summary> 选中目标 </summary>
	public TilingObject value;

	public virtual void Awake() => value = target as TilingObject;

	public override void OnInspectorGUI() {
		base.OnInspectorGUI();
		if (GUILayout.Button("重新计算")) { Initial(); }
	}

	/// <summary> 初始化 </summary>
	private void Initial() {
		DestroyMapSpace();
		for (int y = 0; y < value.size.y; y++)
			for (int x = 0; x < value.size.x; x++)
				Initial(x, y);
		//注册到Undo系统,允许撤销
		Undo.RegisterCreatedObjectUndo(value, $"初始化 {value.gameObject.name}");
	}
	/// <summary> 初始化 </summary>
	private void Initial(int x, int y) {
		Transform obj = Instantiate(value.obj, value.transform);

		Vector3 origin = value.transform.position;
		obj.position = origin + new Vector3(x, 0, y) * value.interval;

		float angle = Random.Range(0, 360);
		obj.eulerAngles = new Vector3(0, angle, 0);

		float localScale = Random.Range(0.8f, 1.2f);
		obj.localScale = new Vector3(localScale, 1, localScale);
	}
	/// <summary> 清空预制件 </summary>
	private void DestroyMapSpace() {
		List<GameObject> list = new List<GameObject>();
		foreach (Transform item in value.transform) { list.Add(item.gameObject); }
		for (int i = 0; i < list.Count; i++) { DestroyImmediate(list[i].gameObject); }
	}
}

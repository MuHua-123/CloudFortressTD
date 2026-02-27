using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 边界测试 - 编辑器
/// </summary>
[CustomEditor(typeof(BoundsTest))]
public class BoundsTestEditor : Editor {
	/// <summary> 选中目标 </summary>
	public BoundsTest value;

	public virtual void Awake() => value = target as BoundsTest;

	public override void OnInspectorGUI() {
		base.OnInspectorGUI();
		if (GUILayout.Button("重新计算")) { value.Initial(); }
	}
}

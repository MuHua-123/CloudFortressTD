using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FixedGridMap))]
public class FixedGridMapEditor : Editor {
	private FixedGridMap value;
	private void Awake() => value = target as FixedGridMap;

	public override void OnInspectorGUI() {
		base.OnInspectorGUI();
		if (GUILayout.Button("初始化地图")) { Initialize(); }
	}

	/// <summary> 初始化地图 </summary>
	private void Initialize() {
		DestroyMapSpace();
		DataGridMap gridMap = new DataGridMap();
		gridMap.wide = value.mapSize.x;
		gridMap.high = value.mapSize.y;
		gridMap.originPosition = value.OriginPosition;
		for (int y = 0; y < gridMap.high; y++) {
			Transform column = GenerateColumn();
			for (int x = 0; x < gridMap.wide; x++) {
				Transform temp = GeneratePrefabs(gridMap, x, y, column);
				value.mapUnit.Add(temp);
			}
		}
		//behaviour.mapVisual.SharedRefreshPlaneGrid(wide, high);
		//注册到Undo系统,允许撤销
		Undo.RegisterCreatedObjectUndo(value, $"初始化地图 {value.gameObject.name}");
	}
	/// <summary> 清空预制件 </summary>
	private void DestroyMapSpace() {
		value.mapUnit = new List<Transform>();
		List<GameObject> list = new List<GameObject>();
		foreach (Transform item in value.mapSpace) { list.Add(item.gameObject); }
		for (int i = 0; i < list.Count; i++) { DestroyImmediate(list[i].gameObject); }
	}
	/// <summary> 生成一列地块的容器 </summary>
	private Transform GenerateColumn() {
		GameObject obj = new GameObject("GameObject");
		obj.transform.SetParent(value.mapSpace);
		return obj.transform;
	}
	/// <summary> 生成地块 </summary>
	private Transform GeneratePrefabs(DataGridMap gridMap, int x, int y, Transform parent) {
		GameObject prefab = value.mapPrefab;
		GameObject obj = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
		obj.transform.SetParent(parent);
		obj.transform.position = gridMap.GetWorldPosition(x, y);
		return obj.transform;
	}
}

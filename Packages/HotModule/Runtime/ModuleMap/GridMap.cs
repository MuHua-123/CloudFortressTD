using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 格子地图
/// </summary>
public class GridMap : MonoBehaviour {

	/// <summary> 地图大小 </summary>
	public Vector2Int mapSize;
	/// <summary> 地图空间 </summary>
	public Transform mapSpace;
	/// <summary> 单元预制 </summary>
	public GameObject mapPrefab;
	/// <summary> 地图单元 </summary>
	public List<Transform> mapUnit;

	public Vector3 OriginPosition => new Vector3(mapSize.x, 0, mapSize.y) * -0.5f;

	public Vector3 GetWorldPosition(int x, int y) {
		Vector3 offset = new Vector3(0.5f, 0, 0.5f);
		return new Vector3(x, 0, y) + OriginPosition + offset;
	}
}

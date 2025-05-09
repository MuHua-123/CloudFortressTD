using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 格子地图
/// </summary>
public class MapGrid : MonoBehaviour {
	public Vector2Int mapSize;
	public Transform mapSpace;
	public GameObject mapPrefab;
	public List<Transform> mapUnit;

	public Vector3 OriginPosition => new Vector3(mapSize.x, 0, mapSize.y) * -0.5f;

	public Vector3 GetWorldPosition(int x, int y) {
		Vector3 offset = new Vector3(0.5f, 0, 0.5f);
		return new Vector3(x, 0, y) + OriginPosition + offset;
	}
}

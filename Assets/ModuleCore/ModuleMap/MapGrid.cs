using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 格子地图
/// </summary>
public class MapGrid : ModuleMap {

	/// <summary> 地图宽 </summary>
	public int wide;
	/// <summary> 地图高 </summary>
	public int high;
	/// <summary> 原点 </summary>
	public Vector3 originPosition;
	/// <summary> 地图单元数据 </summary>
	public DataMapUnit[,] unitArray;

	public MapGrid(int wide, int high, Vector3 originPosition) {
		this.wide = wide;
		this.high = high;
		this.originPosition = originPosition;

		unitArray = new DataMapUnit[wide, high];
		Loop(Initialize);
	}

	public override bool TryWorldPosition(Vector3 worldPosition, out Vector3 position) {
		GetXY(worldPosition, out int x, out int y);
		position = GetWorldPosition(x, y);
		return TryGetXY(x, y);
	}

	/// <summary> 初始化单元 </summary>
	public void Initialize(int x, int y) {
		DataMapUnit mapUnit = new DataMapUnit();
		mapUnit.x = x;
		mapUnit.y = y;
		unitArray[x, y] = mapUnit;
	}
	/// <summary> 遍历地图 </summary>
	public void Loop(Action<int, int> action) {
		for (int y = 0; y < high; y++) {
			for (int x = 0; x < wide; x++) { action?.Invoke(x, y); }
		}
	}
	/*-------------------------------------------------校验范围--------------------------------------------------------------*/
	public bool TryWorldPosition(Vector3 worldPosition, out int x, out int y) {
		GetXY(worldPosition, out x, out y);
		return TryGetXY(x, y);
	}
	public bool TryGetXY(int x, int y) {
		return x >= 0 && x < wide && y >= 0 && y < high;
	}
	/*-------------------------------------------------坐标转换--------------------------------------------------------------*/
	public Vector3 GetWorldPosition(Vector3 worldPosition) {
		GetXY(worldPosition, out int x, out int y);
		return GetWorldPosition(x, y);
	}
	public Vector3 GetWorldPosition(int x, int y) {
		Vector3 offset = new Vector3(0.5f, 0, 0.5f);
		return new Vector3(x, 0, y) + originPosition + offset;
	}
	public void GetXY(Vector3 worldPosition, out int x, out int y) {
		x = Mathf.FloorToInt((worldPosition - originPosition).x);
		y = Mathf.FloorToInt((worldPosition - originPosition).z);
	}
	/*-------------------------------------------------单元操作--------------------------------------------------------------*/
	public DataMapUnit GetMapUnit(Vector3 worldPosition) {
		GetXY(worldPosition, out int x, out int y);
		return GetMapUnit(x, y);
	}
	public DataMapUnit GetMapUnit(int x, int y) {
		x = Mathf.Clamp(x, 0, wide - 1);
		y = Mathf.Clamp(y, 0, high - 1);
		return unitArray[x, y];
	}
	public void SetMapUnit(Vector3 worldPosition, DataMapUnit mapUnit) {
		GetXY(worldPosition, out int x, out int y);
		SetMapUnit(x, y, mapUnit);
	}
	public void SetMapUnit(int x, int y, DataMapUnit mapUnit) {
		x = Mathf.Clamp(x, 0, wide - 1);
		y = Mathf.Clamp(y, 0, high - 1);
		unitArray[x, y] = mapUnit;
	}
	/*-------------------------------------------------校验单元--------------------------------------------------------------*/
	public bool TryGetMapUnit(Vector3 worldPosition, out DataMapUnit unit) {
		GetXY(worldPosition, out int x, out int y);
		return TryGetMapUnit(x, y, out unit);
	}
	public bool TryGetMapUnit(int x, int y, out DataMapUnit unit) {
		unit = GetMapUnit(x, y);
		return TryGetXY(x, y);
	}
	public bool TrySetMapUnit(Vector3 worldPosition, DataMapUnit mapUnit) {
		GetXY(worldPosition, out int x, out int y);
		return TrySetMapUnit(x, y, mapUnit);
	}
	public bool TrySetMapUnit(int x, int y, DataMapUnit mapUnit) {
		if (TryGetXY(x, y)) { unitArray[x, y] = mapUnit; return true; }
		else { return false; }
	}
	/*-------------------------------------------------查询范围--------------------------------------------------------------*/
	/// <summary> 获取相邻的节点 </summary>
	public List<DataMapUnit> FindNeighbour(int x, int y) {
		List<DataMapUnit> neighbourList = new List<DataMapUnit>();
		neighbourList.AddRange(FindConnected(x, y));
		if (TryGetMapUnit(x + 1, y + 1, out DataMapUnit unit5)) { neighbourList.Add(unit5); }
		if (TryGetMapUnit(x + 1, y - 1, out DataMapUnit unit6)) { neighbourList.Add(unit6); }
		if (TryGetMapUnit(x - 1, y + 1, out DataMapUnit unit7)) { neighbourList.Add(unit7); }
		if (TryGetMapUnit(x - 1, y - 1, out DataMapUnit unit8)) { neighbourList.Add(unit8); }
		return neighbourList;
	}
	/// <summary> 获取相连的节点 </summary>
	public List<DataMapUnit> FindConnected(int x, int y) {
		List<DataMapUnit> neighbourList = new List<DataMapUnit>();
		if (TryGetMapUnit(x, y + 1, out DataMapUnit unit1)) { neighbourList.Add(unit1); }
		if (TryGetMapUnit(x, y - 1, out DataMapUnit unit2)) { neighbourList.Add(unit2); }
		if (TryGetMapUnit(x + 1, y, out DataMapUnit unit3)) { neighbourList.Add(unit3); }
		if (TryGetMapUnit(x - 1, y, out DataMapUnit unit4)) { neighbourList.Add(unit4); }
		return neighbourList;
	}
}

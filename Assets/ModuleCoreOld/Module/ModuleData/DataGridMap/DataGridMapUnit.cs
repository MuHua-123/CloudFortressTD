using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 格子地图单元数据
/// </summary>
public class DataGridMapUnit {
	/// <summary> x坐标 </summary>
	public int x;
	/// <summary> y坐标 </summary>
	public int y;
	/// <summary> 建筑物 </summary>
	public IBuilding building;
	/// <summary> 地块 </summary>
	public FixedGridMapUnit fixedGridMapUnit;
	/// <summary> 连接墙 </summary>
	public List<DataConnectWall> connectWalls = new List<DataConnectWall>();

	/// <summary> 代价 </summary>
	public int GCost;
	/// <summary> 代价 </summary>
	public int HCost;
	/// <summary> 代价 </summary>
	public int FCost;
	/// <summary> 来自节点 </summary>
	public DataGridMapUnit CameFromNode;

	/// <summary> 是否可以建造 </summary>
	public bool isBuild => fixedGridMapUnit != null && building == null;
	/// <summary> 是否可以行走 </summary>
	public bool IsWalkable => fixedGridMapUnit != null && building == null;
}
/// <summary>
/// 格子地图单元工具
/// </summary>
public static class DataGridMapUnitTool {
	/// <summary> 初始化寻路成本 </summary>
	public static void InitializationCost(this DataGridMapUnit mapUnit) {
		mapUnit.GCost = int.MaxValue;
		mapUnit.CalculateFCost();
		mapUnit.CameFromNode = null;
	}
	/// <summary> 计算寻路成本 </summary>
	public static void CalculateFCost(this DataGridMapUnit mapUnit) {
		mapUnit.FCost = mapUnit.GCost + mapUnit.HCost;
	}
}
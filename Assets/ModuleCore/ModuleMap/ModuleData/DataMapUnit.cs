using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 地图单元数据
/// </summary>
public class DataMapUnit {
	/// <summary> X坐标 </summary>
	public int x;
	/// <summary> Y坐标 </summary>
	public int y;

	/// <summary> 代价 </summary>
	public int GCost;
	/// <summary> 代价 </summary>
	public int HCost;
	/// <summary> 代价 </summary>
	public int FCost;
	/// <summary> 来自节点 </summary>
	public DataMapUnit cameFromNode;

	/// <summary> 地图单元空间 </summary>
	public IMapUnitSpace mapSpace;

	/// <summary> 是否可以行走 </summary>
	public bool IsWalkable => mapSpace != null && mapSpace.IsWalkable;
}

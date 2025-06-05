using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 生产 - 建筑
/// </summary>
public class HBuildingSpawn : HBuilding {
	/// <summary> 目的地 </summary>
	public HBuildingFinal final;
	/// <summary> 生产队列 </summary>
	public List<ConstSpawn> spawns;
}

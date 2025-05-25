using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 地图 - 管理器
/// </summary>
public class ManagerMap : ModuleSingle<ManagerMap> {

	public ModuleMap moduleMap;// 地图模块

	protected override void Awake() => NoReplace(false);

	/// <summary> 初始化 </summary>
	public void Initialize() {
		if (CreateMapGrid()) { Debug.Log("成功创建格子地图!"); return; }
		Debug.LogWarning("场景中未找到任何Map对象");
	}
	/// <summary> 创建格子地图 </summary>
	public bool CreateMapGrid() {
		// 初始化地图数据
		if (!Utilities.FindObject(out GridMap gridMap)) { return false; }
		MapGrid mapGrid = new MapGrid(gridMap.mapSize.x, gridMap.mapSize.y, gridMap.OriginPosition);
		// 创建地图空间
		Utilities.FindObjects<MapUnit>((obj) => {
			mapGrid.TryGetMapUnit(obj.transform.position, out DataMapUnit mapUnit);
			mapUnit.mapSpace = new DataMapSpace();
		});
		//填充建筑
		moduleMap = mapGrid;
		return true;
	}

	/// <summary> 世界坐标转换地图坐标 </summary>
	public static bool TryWorldPosition(Vector3 worldPosition, out Vector3 position) {
		return I.moduleMap.TryWorldPosition(worldPosition, out position);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 地图 - 管理器
/// </summary>
public class ManagerMap : ModuleSingle<ManagerMap> {

	public MMap mMap;// 地图模块

	protected override void Awake() => NoReplace(false);

	/// <summary> 初始化 </summary>
	public void Initial() {
		// 查找地图对象
		if (!Utilities.FindObject(out HMap hMap)) { return; }
		// 判断类型
		if (hMap is HMapGrid mapGrid) { Initial(mapGrid); }
	}
	public void Initial(HMapGrid hMap) {
		// 初始化地图数据
		mMap = new MMapGrid(hMap.mapSize.x, hMap.mapSize.y, hMap.OriginPosition);
		// 创建地图空间
		Utilities.FindObjects<HMapUnit>(Initial);
		// 填充建筑
		Utilities.FindObjects<HBuilding>(Initial);
	}

	/// <summary> 创建地图空间 </summary>
	public void Initial(HMapUnit obj) {
		if (!mMap.TryGetMapUnit(obj.transform.position, out MMapUnit mapUnit)) { return; }
		mapUnit.mapSpace = new DataMapSpace();
	}
	/// <summary> 创建初始建筑 </summary>
	public void Initial(HBuilding obj) {
		if (!mMap.TryGetMapUnit(obj.transform.position, out MMapUnit mapUnit)) { return; }
		if (mapUnit.mapSpace is DataMapSpace space) { space.building = obj.transform; }
	}

	/// <summary> 世界坐标转换地图坐标 </summary>
	public static bool TryWorldPosition(Vector3 worldPosition, out Vector3 position) {
		return I.mMap.TryWorldPosition(worldPosition, out position);
	}
}

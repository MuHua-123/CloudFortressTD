using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 建筑 - 控制器
/// </summary>
public abstract class CBuilding : MonoBehaviour {

	public abstract void Initial();

	public static CBuilding AddControl(HBuilding hBuilding) {
		if (hBuilding is HBuildingFinal final) { return hBuilding.gameObject.AddComponent<CBuildingFinal>(); }
		if (hBuilding is HBuildingSpawn spawn) { return hBuilding.gameObject.AddComponent<CBuildingSpawn>(); }
		return null;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 生产 - 控制器
/// </summary>
public class CBuildingSpawn : MonoBehaviour {

	public HBuildingSpawn hSpawn;

	/// <summary> 初始化炮塔 </summary>
	public void Init() {
		hSpawn = GetComponent<HBuildingSpawn>();
	}

	private void Update() {

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物生产
/// </summary>
public class MonsterSpawn : MonoBehaviour {
	/// <summary> 生产数据 </summary>
	public MonsterSpawnData spawnData;

	private void Update() => spawnData?.Update();

	/// <summary> 设置生产数据 </summary> 
	public void Settings(MonsterSpawnData spawnData) {
		this.spawnData = spawnData;
		spawnData?.Settings(Generate);
	}
	/// <summary> 生成 </summary> 
	public void Generate(Transform prefab) {

	}
}

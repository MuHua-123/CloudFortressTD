using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 生产建筑 - 控制器
/// </summary>
public class CBuildingSpawn : CBuilding {

	/// <summary> 热更模块 </summary>
	public HBuildingSpawn hSpawn;

	/// <summary> 生产时间 </summary>
	private float time;
	/// <summary> 生产队列 </summary>
	private List<DataSpawn> spawns = new List<DataSpawn>();

	/// <summary> 初始化生产 </summary>
	public override void Initial() {
		hSpawn = GetComponent<HBuildingSpawn>();

		ManagerBattle.OnNewWave += ManagerBattle_OnNewWave;
	}
	private void OnDestroy() {
		ManagerBattle.OnNewWave -= ManagerBattle_OnNewWave;
	}

	private void ManagerBattle_OnNewWave(int obj) {
		if (obj >= hSpawn.spawns.Count) { return; }
		ConstSpawn constSpawn = hSpawn.spawns[obj - 1];
		DataSpawn spawn = constSpawn.GetSpawn(time);
		spawns.Add(spawn);
	}

	/// <summary> 更新生产 </summary>
	private void Update() {
		time += Time.deltaTime;
		for (int i = 0; i < spawns.Count; i++) { UpdateSpawn(spawns[i]); }
	}
	/// <summary> 更新生产 </summary>
	private void UpdateSpawn(DataSpawn spawn) {
		float differ = time - spawn.startTime;
		for (int i = 0; i < spawn.spawnUnits.Count; i++) {
			DataSpawnUnit unit = spawn.spawnUnits[i];
			if (unit.spawnTime > differ) { continue; }
			spawn.spawnUnits.Remove(unit);
			Debug.Log($"创建怪物：{unit.hMonster}");
		}
		if (spawn.spawnUnits.Count == 0) { spawns.Remove(spawn); }
	}
}

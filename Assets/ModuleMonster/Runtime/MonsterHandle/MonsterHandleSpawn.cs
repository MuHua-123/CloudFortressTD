using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 怪物管理器
/// </summary>
public class MonsterHandleSpawn : ModuleSingle<MonsterHandleSpawn> {

	/// <summary> 全部结束 </summary>
	public bool allEnded;
	/// <summary> 怪物波次 </summary>
	public MonsterWave monsterWave;
	/// <summary> 生产列表 </summary>
	public List<MonsterSpawn> spawns = new List<MonsterSpawn>();
	/// <summary> 生产数据列表 </summary>
	public List<MonsterSpawnData> spawnDatas = new List<MonsterSpawnData>();

	protected override void Awake() => NoReplace(false);

	private void Update() {
		allEnded = spawnDatas != null && spawnDatas.All(x => x.IsEnd);
	}

	/// <summary> 初始化生产 </summary>
	public void InitialSpawn(MonsterWaveConst waveConst) {
		// 初始化波次
		monsterWave = waveConst.To();
		// 初始化生产列表
		spawns = new List<MonsterSpawn>();
		Utilities.FindObjects<MonsterSpawn>(spawns.Add);
	}
	/// <summary> 开始生产 </summary>
	public void Spawn() {
		if (spawns == null || spawns.Count == 0) { return; }
		if (monsterWave == null) { return; }
		int count = spawns.Count;
		spawnDatas = monsterWave.Generate(count);
		for (int i = 0; i < count; i++) { Spawn(i); }
	}
	/// <summary> 开始生产 </summary>
	public void Spawn(int i) {
		if (spawns.Count >= i) { return; }
		if (spawnDatas.Count >= i) { return; }
		MonsterSpawn spawn = spawns[i];
		MonsterSpawnData spawnData = spawnDatas[i];
		spawn.Settings(spawnData);
	}
}

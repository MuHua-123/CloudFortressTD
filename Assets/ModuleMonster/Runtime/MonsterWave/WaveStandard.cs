using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 标准 - 怪物波次
/// </summary>
public class WaveStandard : MonsterWave {
	/// <summary> 波次 </summary>
	public int index = 0;
	/// <summary> 总波次 </summary>
	public List<WaveStandardUnit> units = new List<WaveStandardUnit>();

	public override Vector2Int Count => new Vector2Int(index, units.Count);

	public WaveStandard(List<WaveStandardUnit> units) => this.units = units;

	public override List<MonsterSpawnData> Generate(int count) {
		WaveStandardUnit unit = GetUnit();
		List<MonsterSpawnData> spawnDatas = new List<MonsterSpawnData>();
		for (int i = 0; i < count; i++) { spawnDatas.Add(Generate(unit)); }
		return spawnDatas;
	}

	/// <summary> 获取单元 </summary> 
	private WaveStandardUnit GetUnit() {
		WaveStandardUnit unit = units.LoopIndex(index);
		index++;
		return unit;
	}
	/// <summary> 生成 </summary> 
	private MonsterSpawnData Generate(WaveStandardUnit unit) {
		SpawnStandard spawnData = new SpawnStandard();
		spawnData.quantity = unit.quantity;
		spawnData.interval = unit.interval;
		spawnData.prefab = unit.prefab;
		return spawnData;
	}
}
/// <summary>
/// 波次单元
/// </summary>
[Serializable]
public class WaveStandardUnit {
	/// <summary> 数量 </summary>
	public int quantity;
	/// <summary> 间隔 </summary>
	public float interval;
	/// <summary> 预制 </summary>
	public Transform prefab;
}
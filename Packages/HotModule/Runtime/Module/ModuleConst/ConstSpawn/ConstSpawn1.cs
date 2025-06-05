using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConstSpawn1", menuName = "数据模块/怪物生产/生产规则1")]
public class ConstSpawn1 : ConstSpawn {
	/// <summary> 生产间隔 </summary>
	public int interval;
	/// <summary> 生产数量 </summary>
	public int quantity;
	/// <summary> 怪物类型 </summary>
	public HMonster hMonster;

	public override DataSpawn GetSpawn() {
		DataSpawn spawn = new DataSpawn();
		for (int i = 0; i < quantity; i++) {
			DataSpawnUnit unit = new DataSpawnUnit();
			unit.spawnTime = i * interval;
			unit.hMonster = hMonster;
			spawn.spawnUnits.Add(unit);
		}
		return spawn;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 生产 - 数据
/// </summary>
public class DataSpawn {
	/// <summary> 开始时间 </summary>
	public float startTime;
	/// <summary> 生产单元 </summary>
	public List<DataSpawnUnit> spawnUnits = new List<DataSpawnUnit>();
}
/// <summary>
/// 生产单元 - 数据
/// </summary>
public class DataSpawnUnit {
	/// <summary> 生产时间 </summary>
	public float spawnTime;
	/// <summary> 怪物类型 </summary>
	public HMonster hMonster;
}
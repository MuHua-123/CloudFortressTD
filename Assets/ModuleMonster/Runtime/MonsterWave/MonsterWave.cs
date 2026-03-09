using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物波次
/// </summary>
public abstract class MonsterWave {

	/// <summary> x = 当前波次，y = 最大波次(-1 = 无限) </summary>
	public abstract Vector2Int Count { get; }

	/// <summary> 生成数据 </summary>
	public abstract List<MonsterSpawnData> Generate(int count);
}

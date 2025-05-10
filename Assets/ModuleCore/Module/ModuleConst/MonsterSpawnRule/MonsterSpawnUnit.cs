using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物生产单元
/// </summary>
public class MonsterSpawnUnit : ScriptableObject {
    /// <summary> 最大生产时间 </summary>
    public float maxSpawnTime;
    /// <summary> 生产数量 </summary>
    public int quantity;
    /// <summary> 生产间隔 </summary>
    public float interval;
    /// <summary> 生产强度 </summary>
    public int strength;
    /// <summary> 怪物数据 </summary>
    public ConstMonster monster;
}
public static class MonsterSpawnUnitTool {
    public static DataMonsterSpawnQueue To(this MonsterSpawnUnit spawnUnit) {
        DataMonsterSpawnQueue spawnQueue = new DataMonsterSpawnQueue();
        spawnQueue.quantity = spawnUnit.quantity;
        spawnQueue.interval = spawnUnit.interval;
        spawnQueue.strength = spawnUnit.strength;
        spawnQueue.monster = spawnUnit.monster;
        return spawnQueue;
    }
}
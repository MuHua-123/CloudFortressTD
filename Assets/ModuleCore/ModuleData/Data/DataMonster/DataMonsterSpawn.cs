using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物生产
/// </summary>
public class DataMonsterSpawn {
    /// <summary> 累计生产时间 </summary>
    public float spawnTime;
    /// <summary> 最大生产时间 </summary>
    public float maxSpawnTime;
    /// <summary> 怪物生产队列 </summary>
    public List<DataMonsterSpawnQueue> spawnQueues = new List<DataMonsterSpawnQueue>();
    /// <summary> 生产倒计时 </summary>
    public float Countdown => maxSpawnTime - spawnTime;
}
/// <summary>
/// 怪物生产队列
/// </summary>
public class DataMonsterSpawnQueue {
    /// <summary> 开始生产时间 </summary>
    public float startTime;
    /// <summary> 生产时间 </summary>
    public float spawnTime = 0.05f;
    /// <summary> 生产间隔 </summary>
    public float interval;
    /// <summary> 生产数量 </summary>
    public int quantity;
    /// <summary> 生产强度 </summary>
    public int strength;
    /// <summary> 怪物预制 </summary>
    public ConstMonster monster;
}
/// <summary>
/// 怪物生产工具
/// </summary>
public static class DataMonsterSpawnTool {
    public static DataMonster To(this DataMonsterSpawnQueue spawnQueue) {
        int strength = spawnQueue.strength;
        return spawnQueue.monster.To(strength);
    }
}
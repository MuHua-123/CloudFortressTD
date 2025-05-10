using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterSpawnRule", menuName = "数据模块/怪物生产/基础规则")]
public class MonsterSpawnRuleBasics : MonsterSpawnRule {
    /// <summary> 数据文件 </summary>
    public TextAsset dataFile;
    /// <summary> 关卡列表 </summary>
    public List<MonsterSpawnUnit> spawnUnits = new List<MonsterSpawnUnit>();

    public override DataMonsterSpawn To(int level) {
        MonsterSpawnUnit spawnUnit = spawnUnits.LoopIndex(level - 1);
        DataMonsterSpawn spawn = new DataMonsterSpawn();
        spawn.spawnQueues.Add(spawnUnit.To());
        spawn.maxSpawnTime = spawnUnit.maxSpawnTime;
        return spawn;
    }
}
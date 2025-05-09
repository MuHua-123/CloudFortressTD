using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 关卡难度
/// </summary>
public class ConstLevelGrade : ScriptableObject {
    /// <summary> 通过计数 </summary>
    public Vector2Int count;
    /// <summary> 生产规则 </summary>
    public List<MonsterSpawnRule> spawnRules;
}
public static class ConstLevelGradeTool {
    public static MonsterSpawnRule To(this ConstLevelGrade grade, int index) {
        return grade.spawnRules.LoopIndex(index);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物预设
/// </summary>
[CreateAssetMenu(fileName = "ConstMonster", menuName = "数据模块/怪物数据")]
public class ConstMonster : ScriptableObject {
    /// <summary> 预览图片 </summary>
    public Sprite icon;
    /// <summary> 预制模型 </summary>
    public Transform prefab;
    /// <summary> 数据文件 </summary>
    public TextAsset dataFile;
    /// <summary> 怪物等级 </summary>
    public List<ConstMonsterGrade> grades;
}
/// <summary>
/// 怪物预设工具
/// </summary>
public static class ConstMonsterTool {
    public static DataMonster To(this ConstMonster constMonster, int strength) {
        DataMonster monster = new DataMonster(constMonster);
        ConstMonsterGrade grade = constMonster.grades[strength - 1];
        monster.cost = grade.cost;
        monster.speed = grade.speed;
        monster.hp = new Vector2Int(grade.hp, grade.hp);
        monster.ac = new Vector2Int(grade.ac, grade.ac);
        monster.es = new Vector2Int(grade.es, grade.es);
        return monster;
    }
}
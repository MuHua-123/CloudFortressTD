using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物等级
/// </summary>
public class ConstMonsterGrade : ScriptableObject {
    /// <summary> 关联的怪物数据 </summary>
    [HideInInspector] public ConstMonster monster;
    /// <summary> 名称 </summary>
    public string Name;

    /// <summary> 价值 </summary>
    public int cost;
    /// <summary> 生命值 </summary>
    public int hp;
    /// <summary> 护甲值 </summary>
    public int ac;
    /// <summary> 护盾值 </summary>
    public int es;
    /// <summary> 移动速度 </summary>
    public float speed;
}

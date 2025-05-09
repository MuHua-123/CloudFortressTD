using System.Collections;
using System.Collections.Generic;
using MuHua;
using UnityEngine;

/// <summary>
/// 炮塔等级
/// </summary>
public class ConstTurretGrade : ScriptableObject
{
    /// <summary> 关联的炮塔数据 </summary>
    [HideInInspector] public ConstTurret turret;
    /// <summary> 名称 </summary>
    public string Name;
    /// <summary> 预览图片 </summary>
    public Sprite icon;
    /// <summary> 预制模型 </summary>
    public Transform prefab;
    /// <summary> 升级价格 </summary>
    public int upgradeValue;

    [Header("基础属性")]
    /// <summary> 基础攻击 </summary>
    public int attack;
    /// <summary> 攻击速度 </summary>
    public float attackSpeed;
    /// <summary> 最小攻击范围 </summary>
    public float minAttackRange;
    /// <summary> 最大攻击范围 </summary>
    public float maxAttackRange;

    [Header("基础技能")]
    /// <summary> 基础技能 </summary>
    public List<ConstTurretSkill> skills;
}

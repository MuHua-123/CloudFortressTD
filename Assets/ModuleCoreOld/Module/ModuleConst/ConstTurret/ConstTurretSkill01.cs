using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 攻击系数 炮塔技能
/// </summary>
[CreateAssetMenu(fileName = "ConstTurretSkill", menuName = "数据模块/炮塔/攻击系数技能")]
public class ConstTurretSkill01 : ConstTurretSkill {
    /// <summary> 生命系数 </summary>
    public int hpFactor;
    /// <summary> 护甲系数 </summary>
    public int acFactor;
    /// <summary> 护盾系数 </summary>
    public int esFactor;

    public override void Property(DataTurretProperty property) {
        property.esFactor += esFactor;
        property.acFactor += acFactor;
        property.hpFactor += hpFactor;
    }
}

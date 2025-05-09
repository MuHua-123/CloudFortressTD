using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 附加攻击 炮塔技能
/// </summary>
[CreateAssetMenu(fileName = "ConstTurretSkill", menuName = "数据模块/炮塔/攻击附加技能")]
public class ConstTurretSkill02 : ConstTurretSkill {
    /// <summary>
    /// 附加技能类型
    /// </summary>
    public enum SkillType { 火焰, 寒冰 }

    /// <summary> 持续时间 </summary>
    public const float DefaultTime = 10f;

    /// <summary> 附加技能等级 </summary>
    public int level = 1;
    /// <summary> 附加技能类型 </summary>
    public SkillType type;

    public override void Attack(DataTurretAttack attack) {
        if (type == SkillType.火焰) { attack.buffs.Add(火焰(level)); }
        if (type == SkillType.寒冰) { attack.buffs.Add(寒冰(level)); }
    }

    private DataBuff 火焰(int level) {
        int speedFactor = 25 * level;
        return new MoveSpeedBuff { time = DefaultTime, speedFactor = speedFactor };
    }
    private DataBuff 寒冰(int level) {
        int speedFactor = 25 * level;
        return new MoveSpeedBuff { time = DefaultTime, speedFactor = speedFactor };
    }
}

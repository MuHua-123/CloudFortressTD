using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 炮塔技能
/// </summary>
public abstract class ConstTurretSkill : ScriptableObject {
    /// <summary> 颜色 </summary>
    public Color color = new Color(1, 1, 1, 1);
    /// <summary> 附加属性统计 </summary>
    public virtual void Property(DataTurretProperty property) { }
    /// <summary> 攻击效果统计 </summary>
    public virtual void Attack(DataTurretAttack attack) { }
}

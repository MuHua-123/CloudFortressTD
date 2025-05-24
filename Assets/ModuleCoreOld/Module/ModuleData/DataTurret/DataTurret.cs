using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 炮塔数据
/// </summary>
public class DataTurret {
    /// <summary> 预设数据 </summary>
    public readonly ConstTurret presets;
    /// <summary> 初始化 </summary>
    public DataTurret(ConstTurret presets) => this.presets = presets;

    /// <summary> 格子地图单元 </summary>
    public DataGridMapUnit mapUnit;
    /// <summary> x坐标 </summary>
    public int X => mapUnit.x;
    /// <summary> y坐标 </summary>
    public int Y => mapUnit.y;

    /// <summary> 炮塔等级 </summary>
    public int grade;
    /// <summary> 建造价格 </summary>
    public int buildValue;
    /// <summary> 等级数据 </summary>
    public ConstTurretGrade turretGrade;
    /// <summary> 炮塔技能 </summary>
    public List<ConstTurretSkill> skills;

    #region 操作属性
    /// <summary> 炮塔名字 </summary>
    public string Name => presets.name;
    /// <summary> 是否可以升级 </summary>
    public bool IsCanUpgraded => grade < presets.grades.Count - 1;
    /// <summary> 预览图片 </summary>
    public Sprite Icon => turretGrade.icon;
    /// <summary> 预制模型 </summary>
    public Transform Prefab => turretGrade.prefab;
    /// <summary> 升级价格 </summary>
    public int UpgradeValue => turretGrade.upgradeValue;
    #endregion

    #region 战斗属性
    /// <summary> 攻击伤害 </summary>
    public int Attack;
    /// <summary> 攻击速度 </summary>
    public float AttackSpeed;
    /// <summary> 最大攻击范围 </summary>
    public float MaxAttackRange;
    /// <summary> 最小攻击范围 </summary>
    public float MinAttackRange;
    /// <summary> 生命系数 </summary>
    public int HpFactor;
    /// <summary> 护甲系数 </summary>
    public int AcFactor;
    /// <summary> 护盾系数 </summary>
    public int EsFactor;
    #endregion

    /// <summary> 可视化内容 </summary>
    public ModulePrefab<DataTurret> visual;
}
public static class DataTurretTool {
    /// <summary> 更新炮塔属性 </summary>
    public static void UpdateProperty(this DataTurret turret) {
        //炮塔基础等级属性
        ConstTurretGrade grade = turret.presets[turret.grade];
        turret.turretGrade = grade;
        //刷新技能
        List<ConstTurretSkill> skills = new List<ConstTurretSkill>();
        skills.AddRange(grade.skills);
        skills.AddRange(turret.presets.skills);
        turret.skills = skills;
        //统计炮塔技能属性
        DataTurretProperty skillStats = new DataTurretProperty();
        skills.ForEach(obj => obj.Property(skillStats));
        //附加最终属性
        turret.Attack = grade.attack;
        turret.AttackSpeed = grade.attackSpeed;
        turret.MaxAttackRange = grade.maxAttackRange;
        turret.MinAttackRange = grade.minAttackRange;
        turret.HpFactor = skillStats.hpFactor;
        turret.AcFactor = skillStats.acFactor;
        turret.EsFactor = skillStats.esFactor;
    }
    /// <summary> 生成子弹 </summary>
    public static DataBullet ToBullet(this DataTurret turret, Transform prefab, PrefabMonster target, Vector3 position) {
        DataBullet bullet = new DataBullet();
        bullet.prefab = prefab;
        bullet.target = target;
        bullet.origin = turret;
        bullet.position = position;

        bullet.bulletDamage = turret.Attack;
        bullet.hpFactor = turret.HpFactor;
        bullet.acFactor = turret.AcFactor;
        bullet.esFactor = turret.EsFactor;
        return bullet;
    }
}
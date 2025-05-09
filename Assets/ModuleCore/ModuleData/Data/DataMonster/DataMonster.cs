using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物数据
/// </summary>
public class DataMonster {
    /// <summary> 常量 </summary>
    public readonly ConstMonster constMonster;
    /// <summary> 初始化 </summary>
    public DataMonster(ConstMonster constMonster) => this.constMonster = constMonster;

    /// <summary> 怪物预制 </summary>
    public Transform Prefab => constMonster.prefab;
    /// <summary> 可视化内容 </summary>
    public ModulePrefab<DataMonster> visual;
    /// <summary> 生命值 </summary>
    public ModulePrefab<DataMonster> hitPoints;

    #region 缓存属性
    /// <summary> 追击目标 </summary>
    public Transform target;
    /// <summary> 当前位置 </summary>
    public Vector3 position;
    /// <summary> 偏移位置 </summary>
    public Vector3 offset;
    /// <summary> 血条的高度 </summary>
    public Vector3 height;
    /// <summary> 是否到达目的地 </summary>
    public bool isDestination;
    /// <summary> 到达终点范围内 </summary>
    public bool isArriveFinal;
    /// <summary> buff统计 </summary>
    public DataBuffStats stats = new DataBuffStats();
    /// <summary> buff列表 </summary>
    public List<DataBuff> buffs = new List<DataBuff>();
    #endregion

    #region 固定属性
    /// <summary> 价值 </summary>
    public int cost;
    /// <summary> 强度 </summary>
    public int strength;
    /// <summary> 移动速度 </summary>
    public float speed;
    /// <summary> 生命值 </summary>
    public Vector2Int hp;
    /// <summary> 护甲值 </summary>
    public Vector2Int ac;
    /// <summary> 能量值 </summary>
    public Vector2Int es;
    #endregion

    #region 实际属性
    /// <summary> 移动速度 </summary>
    public float Speed => speed * Mathf.Max(1 + (stats.speedFactor / 1000f), 0.3f);
    #endregion

}
public static class DataMonsterTool {
    public static DataDamage To(this DataMonster monster, DataAttack attack) {
        DataDefense defense = new DataDefense();
        defense.hp = monster.hp.x;
        defense.ac = monster.ac.x;
        defense.es = monster.es.x;
        defense.buffs = monster.buffs;
        DataDamage damage = new DataDamage();
        damage.attack = attack;
        damage.defense = defense;
        return damage;
    }

    public static void To(this DataMonster monster, DataDefense defense) {
        monster.es.x = defense.es > 0 ? defense.es : 0;
        monster.ac.x = defense.ac > 0 ? defense.ac : 0;
        monster.hp.x = defense.hp > 0 ? defense.hp : 0;
        monster.buffs = defense.buffs;
    }
}

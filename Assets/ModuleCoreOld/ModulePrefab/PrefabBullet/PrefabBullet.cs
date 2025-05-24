using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 子弹抽象
/// </summary>
public abstract class PrefabBullet : ModulePrefab<DataBullet> {
    /// <summary> 命中目标 </summary>
    public abstract bool IsHit { get; }
    /// <summary> 目标 </summary>
    public virtual PrefabMonster Target => Value.target;
    /// <summary> 目标位置 </summary>
    public virtual Vector3 TargetPosition => Target.body.position;
    /// <summary> 子弹速度 </summary>
    public virtual float BulletSpeed => 10;
    /// <summary> 游戏速度 </summary>
    protected virtual float PlaySpeed => ModuleCore.HandleGameState.Current.PlaySpeed * Time.deltaTime;

    /// <summary> 临时道具 执行模块 </summary>
    public ModuleExecute<DataTemporaryProps> ExecuteTemporaryProps => ModuleCore.ExecuteTemporaryProps;
    /// <summary> 炮弹 DataBullet 可视化内容生成模块 </summary>
    public ModuleVisualOld<DataBullet> VisualBullet => ModuleCore.VisualBullet;

    public virtual void Update() {
        if (Target != null) { TrackTarget(); }
        else { LostTarget(); }
        if (IsHit) { HitTarget(); }
    }

    /// <summary> 追击目标 </summary>
    public virtual void TrackTarget() { throw new System.NotImplementedException(); }
    /// <summary> 丢失目标 </summary>
    public virtual void LostTarget() { throw new System.NotImplementedException(); }
    /// <summary> 命中目标 </summary>
    public virtual void HitTarget() { throw new System.NotImplementedException(); }
}
/// <summary>
/// 子弹数据
/// </summary>
public class DataBullet {
    /// <summary> 预制件 </summary>
    public Transform prefab;
    /// <summary> 目标 </summary>
    public PrefabMonster target;
    /// <summary> 来源 </summary>
    public object origin;
    /// <summary> 发射点 </summary>
    public Vector3 position;

    /// <summary> 可视化内容 </summary>
    public ModulePrefab<DataBullet> visual;

    /// <summary> 子弹伤害 </summary>
    public int bulletDamage;
    /// <summary> 生命系数 </summary>
    public int hpFactor;
    /// <summary> 护甲系数 </summary>
    public int acFactor;
    /// <summary> 护盾系数 </summary>
    public int esFactor;
}
/// <summary>
/// 子弹工具
/// </summary>
public static class DataBulletTool {
    /// <summary> 生成攻击指令 </summary>
    public static DataAttack To(this DataBullet bullet) {
        DataAttack attack = new DataAttack();
        attack.value = bullet.bulletDamage;
        attack.hpFactor = bullet.hpFactor;
        attack.acFactor = bullet.acFactor;
        attack.esFactor = bullet.esFactor;
        return attack;
    }
}
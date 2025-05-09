using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 发射器功能
/// </summary>
public abstract class TurretComponentLaunch : TurretComponent {
    protected float prepareTime;//准备时间
    protected DataTurret turret;

    /// <summary> 瞄准器 </summary>
    public TurretComponentAim AimTarget => GetComponent<TurretComponentAim>();
    /// <summary> 目标 </summary>
    public virtual PrefabMonster Target => AimTarget.Target;
    /// <summary> 是否准备完成 </summary>
    protected virtual bool IsPrepare => prepareTime < 0;
    /// <summary> 最大准备时间 </summary>
    protected virtual float MaxPrepareTime => turret.AttackSpeed;
    /// <summary> 游戏速度 </summary>
    protected virtual float PlaySpeed => ModuleCore.HandleGameState.Current.PlaySpeed * Time.deltaTime;

    protected virtual void Update() {
        if (turret == null) { return; }
        if (prepareTime >= 0) { prepareTime -= PlaySpeed; }
        if (!IsPrepare || !AimTarget.IsLockTarget) { return; }
        prepareTime = MaxPrepareTime;
        Launcher();
    }

    /// <summary> 初始化侦测功能 </summary>
    public virtual void Initialize(DataTurret turret) {
        this.turret = turret;
        prepareTime = MaxPrepareTime;
    }
    /// <summary> 发射 </summary>
    protected abstract void Launcher();
}

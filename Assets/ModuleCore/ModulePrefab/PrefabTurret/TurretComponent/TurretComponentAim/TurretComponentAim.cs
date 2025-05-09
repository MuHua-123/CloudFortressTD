using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 瞄准功能
/// </summary>
public abstract class TurretComponentAim : TurretComponent {
    /// <summary> 目标 </summary>
    public virtual PrefabMonster Target => Detection.Target;
    /// <summary> 目标位置 </summary>
    public virtual Vector3 TargetPosition => Target.transform.position;
    /// <summary> 侦测功能 </summary>
    public TurretComponentDetection Detection => GetComponent<TurretComponentDetection>();
    /// <summary> 游戏速度 </summary>
    public virtual float PlaySpeed => ModuleCore.HandleGameState.Current.PlaySpeed * Time.deltaTime * 10;

    /// <summary> 是否锁定目标 </summary>
    public abstract bool IsLockTarget { get; }
    /// <summary> 瞄准目标 </summary>
    public abstract void AimTarget();

    protected virtual void Update() { if (Target != null) { AimTarget(); } }
}

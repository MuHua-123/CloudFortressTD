using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 侦测功能
/// </summary>
public abstract class TurretComponentDetection : TurretComponent {
    /// <summary> 倒计时 </summary>
    protected float time;
    /// <summary> 当前炮塔 </summary>
    protected DataTurret turret;
    /// <summary> 最大侦测间隔 </summary>
    protected virtual float MaxTime => 0.5f;
    /// <summary> 游戏速度 </summary>
    protected virtual float PlaySpeed => ModuleCore.HandleGameState.Current.PlaySpeed * Time.deltaTime;

    public abstract PrefabMonster Target { get; }

    protected virtual void Update() {
        if (turret == null) { return; }
        time -= PlaySpeed;
        if (time <= 0) { time = MaxTime; FindTarget(); }
    }

    /// <summary> 初始化侦测功能 </summary>
    public virtual void Initialize(DataTurret turret) => this.turret = turret;
    /// <summary> 查询目标 </summary>
    public abstract void FindTarget();
}
/// <summary> 
/// 目标信息
/// </summary>
public class TargetInfo {
    /// <summary> 目标 </summary>
    public PrefabMonster target;
    /// <summary> 直线距离 </summary>
    public float distance = float.MaxValue;
    /// <summary> 目标位置 </summary>
    public Vector3 position => target.transform.position;
}
public static class TargetInfoTool {
    public static TargetInfo To(this PrefabMonster target, Vector3 position) {
        TargetInfo targetInfo = new TargetInfo();
        targetInfo.target = target;
        targetInfo.distance = Vector3.Distance(position, targetInfo.position);
        return targetInfo;
    }
}
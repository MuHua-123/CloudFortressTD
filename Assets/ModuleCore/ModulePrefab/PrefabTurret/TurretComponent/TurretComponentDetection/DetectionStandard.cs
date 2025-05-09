using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 标准侦测
/// </summary>
public class DetectionStandard : TurretComponentDetection {
    private TargetInfo info = new TargetInfo();

    public LayerMask Monster => LayerMaskTool.Monster;
    public float Range => turret.MaxAttackRange;
    public override PrefabMonster Target => info.target;

    public override void FindTarget() {
        List<TargetInfo> targets = FindAllTarget();
        info = FindRecentTarget(targets);
    }

    /// <summary> 查询全部目标 </summary>
    private List<TargetInfo> FindAllTarget() {
        return FindAllTarget(transform.position, Range, Monster);
    }
    /// <summary> 查询最近目标 </summary>
    private TargetInfo FindRecentTarget(List<TargetInfo> targets) {
        TargetInfo targetInfo = new TargetInfo();
        for (int i = 0; i < targets.Count; i++) {
            if (targetInfo.distance < targets[i].distance) { continue; }
            targetInfo = targets[i];
        }
        return targetInfo;
    }

    /// <summary> 查询全部目标 </summary>
    public static List<TargetInfo> FindAllTarget(Vector3 position, float range, LayerMask mask) {
        Collider[] colliders = Physics.OverlapSphere(position, range, mask);
        List<TargetInfo> targets = new List<TargetInfo>();
        for (int i = 0; i < colliders.Length; i++) {
            PrefabMonster monster = colliders[i].GetComponentInParent<PrefabMonster>();
            if (monster != null) { targets.Add(monster.To(position)); }
        }
        return targets;
    }
}

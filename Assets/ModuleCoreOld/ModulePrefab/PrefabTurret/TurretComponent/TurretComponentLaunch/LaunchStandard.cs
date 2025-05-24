using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchStandard : TurretComponentLaunch {
    public Transform firePoint;
    public Transform bulletPrefab;

    public Animator animator => GetComponent<Animator>();

    /// <summary> 炮弹 DataBullet 可视化内容生成模块 </summary>
    public ModuleVisualOld<DataBullet> VisualBullet => ModuleCore.VisualBullet;

    protected override void Launcher() {
        animator.SetTrigger("Fire");
        DataBullet bullet = turret.ToBullet(bulletPrefab, Target, firePoint.position);
        VisualBullet.UpdateVisual(bullet);
    }
}

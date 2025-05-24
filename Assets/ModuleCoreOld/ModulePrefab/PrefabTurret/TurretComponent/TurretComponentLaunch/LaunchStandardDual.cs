using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchStandardDual : TurretComponentLaunch {
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform bulletPrefab;
    private bool isRight;

    public Animator animator => GetComponent<Animator>();

    /// <summary> 炮弹 DataBullet 可视化内容生成模块 </summary>
    public ModuleVisualOld<DataBullet> VisualBullet => ModuleCore.VisualBullet;

    protected override void Launcher() {
        animator.SetTrigger("Fire");
        firePoint1.gameObject.SetActive(!isRight);
        firePoint2.gameObject.SetActive(isRight);
        Transform firePoint = isRight ? firePoint2 : firePoint1;
        DataBullet bullet = turret.ToBullet(bulletPrefab, Target, firePoint.position);
        VisualBullet.UpdateVisual(bullet);
        isRight = !isRight;
    }
}

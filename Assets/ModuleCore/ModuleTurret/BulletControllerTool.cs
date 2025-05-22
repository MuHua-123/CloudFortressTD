using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 子弹控制器 - 工具
/// </summary>
public static class BulletControllerTool {

	public static Bullet Init(this BulletBasic bulletBasic, TurretController turretController, ITurretTarget initTarget, BulletController controller) {
		StandardBullet standardBullet = bulletBasic as StandardBullet;
		if (standardBullet != null) { return standardBullet.Init(turretController, initTarget, controller); }
		return null;
	}

	public static Bullet Init(this StandardBullet template, TurretController turretController, ITurretTarget initTarget, BulletController controller) {
		BulletStandard bulletStandard = new BulletStandard();
		// 初始化
		bulletStandard.Init(controller.transform, initTarget, turretController.turretData.bulletSpeed);
		// 初始化命中
		bulletStandard.InitHit(controller.HitComparer, controller.HitTarget);
		// 初始化命中特效
		bulletStandard.InitHitEffect(template.hitEffect, Transform.Instantiate);

		return bulletStandard;
	}

}

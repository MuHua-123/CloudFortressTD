using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 标准子弹 - 控制器
/// </summary>
public class CBulletStandard : CBullet {

	public HBulletStandard hBullet;
	public MBulletStandard mBullet;

	private CTurret cTurret;

	private void Update() => mBullet.Update();

	/// <summary> 初始化子弹 </summary>
	public override void Initial(CTurret cTurret, ITurretTarget initTarget, Transform firePoint) {
		this.cTurret = cTurret;
		hBullet = GetComponent<HBulletStandard>();
		// 初始化
		mBullet.Init(transform, initTarget, cTurret.Data.bulletSpeed);
		// 初始化命中
		mBullet.InitHit(HitComparer, HitTarget);
		// 初始化命中特效
		mBullet.InitHitEffect(hBullet.hitEffect, Instantiate);
		// 初始位置
		transform.position = firePoint.position;
		transform.LookAt(initTarget.Position);
	}

	/// <summary> 命中比较器 </summary>
	public bool HitComparer(ITurretTarget hitTarget) {
		return false;
	}
	/// <summary> 命中目标 </summary>
	public void HitTarget(ITurretTarget target, Vector3 position) {
		Debug.Log($"{target} , {position}");
	}
}

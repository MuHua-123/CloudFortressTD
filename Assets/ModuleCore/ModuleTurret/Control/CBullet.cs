using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 子弹 - 控制器
/// </summary>
public class CBullet : MonoBehaviour {

	public HBullet hBullet;
	public MBullet mBullet;

	private CTurret cTurret;

	private void Update() => mBullet.Update();

	/// <summary> 初始化子弹 </summary>
	public void Init(CTurret cTurret, ITurretTarget initTarget) {
		this.cTurret = cTurret;
		hBullet = GetComponent<HBullet>();
		if (hBullet is HBulletStandard standardBullet) { Init(standardBullet, initTarget); }
	}
	public void Init(HBulletStandard hBullet, ITurretTarget initTarget) {
		MBulletStandard bulletStandard = new MBulletStandard();
		// 初始化
		bulletStandard.Init(transform, initTarget, cTurret.dTurret.bulletSpeed);
		// 初始化命中
		bulletStandard.InitHit(HitComparer, HitTarget);
		// 初始化命中特效
		bulletStandard.InitHitEffect(hBullet.hitEffect, Instantiate);

		mBullet = bulletStandard;
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

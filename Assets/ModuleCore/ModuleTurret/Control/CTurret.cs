using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using MuHua;

/// <summary>
/// 炮塔 - 控制器
/// </summary>
public class CTurret : MonoBehaviour {

	public HTurret hTurret;
	public DTurret dTurret;
	public MTurret mTurret;

	private void Update() => mTurret?.Update();

	/// <summary> 初始化炮塔 </summary>
	public void Init() {
		hTurret = GetComponent<HTurret>();
		if (hTurret is HTurretStandard turretStandard) { Init(turretStandard); }
	}
	public void Init(HTurretStandard hTurret) {
		MTurretStandard turretStandard = new MTurretStandard();
		// 初始化瞄准模块
		turretStandard.InitAim(hTurret.headY, hTurret.headX);
		// 初始化发射模块
		turretStandard.InitLaunch(() => dTurret.launchInterval, (initTarget) => { LaunchBullet(hTurret.bulletPrefab, initTarget); });
		// 初始化侦察模块
		turretStandard.InitDetection(transform, () => dTurret.range, hTurret.layerMask, DetectionComparer);

		mTurret = turretStandard;
		dTurret = new DTurret(hTurret);
	}

	/// <summary> 发射子弹 </summary>
	public void LaunchBullet(Transform bulletPrefab, ITurretTarget initTarget) {
		hTurret.animator.SetTrigger("Fire");
		Transform bullet = Transform.Instantiate(bulletPrefab);
		CBullet bulletController = bullet.AddComponent<CBullet>();
		bulletController.Init(this, initTarget);
	}
	/// <summary> 侦察比较器 </summary>
	public bool DetectionComparer(ITurretTarget ta1, ITurretTarget ta2) {
		return false;
	}
}

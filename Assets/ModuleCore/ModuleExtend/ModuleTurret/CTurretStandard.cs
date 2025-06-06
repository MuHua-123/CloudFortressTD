using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using MuHua;

/// <summary>
/// 标准炮塔 - 控制器
/// </summary>
public class CTurretStandard : CTurret {

	public DataTurret dTurret;
	public HTurretStandard hTurret;
	public MTurretStandard mTurret;

	public override DataTurret Data { get; }

	/// <summary> 范围 </summary>
	public float Range => Data.range;
	/// <summary> 发生间隔 </summary>
	public float LaunchInterval => Data.launchInterval;

	private void Update() => mTurret?.Update();

	/// <summary> 初始化炮塔 </summary>
	public override void Initial() {
		hTurret = GetComponent<HTurretStandard>();
		mTurret = new MTurretStandard();
		// 初始化瞄准模块
		mTurret.InitAim(hTurret.headY, hTurret.headX);
		// 初始化发射模块
		mTurret.InitLaunch(() => LaunchInterval, LaunchBullet);
		// 初始化侦察模块
		mTurret.InitDetection(transform, () => Range, hTurret.layerMask, DetectionComparer);
		// 初始化数据
		dTurret = new DataTurret(hTurret);
		// 初始动画
		hTurret.animator.SetTrigger("Install");
	}

	/// <summary> 发射子弹 </summary>
	public void LaunchBullet(ITurretTarget initTarget) {
		hTurret.animator.SetTrigger("Fire");
		HBullet hBullet = ModuleVisual.I.HBullet.CreateVisual(hTurret.bulletPrefab);
		CBullet control = CBullet.AddControl(hBullet);
		control.Initial(this, initTarget, hTurret.firePoint);
	}
	/// <summary> 侦察比较器 </summary>
	public bool DetectionComparer(ITurretTarget ta1, ITurretTarget ta2) {
		return false;
	}
}

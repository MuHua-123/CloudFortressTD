using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;
using Unity.VisualScripting;

/// <summary>
/// 炮塔控制器 - 工具
/// </summary>
public static class TurretControllerTool {

	public static Turret Init(this TurretBasic turretBasic, TurretController controller) {
		StandardTurret standardTurret = turretBasic as StandardTurret;
		if (standardTurret != null) { return standardTurret.Init(controller); }
		return null;
	}

	public static Turret Init(this StandardTurret template, TurretController controller) {
		TurretStandard turretStandard = new TurretStandard();
		// 初始化瞄准模块
		turretStandard.InitAim(template.headY, template.headX);
		// 初始化发射模块
		turretStandard.InitLaunch(() => controller.turretData.launchInterval, (initTarget) => {
			controller.LaunchBullet(template.bulletPrefab, initTarget);
		});
		// 初始化侦察模块
		turretStandard.InitDetection(controller.transform, () => controller.turretData.range, template.layerMask, controller.DetectionComparer);

		return turretStandard;
	}
}

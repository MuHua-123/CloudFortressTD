using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 炮塔数据 - 工具
/// </summary>
public static class TurretDataTool {

	public static TurretData Data(this TurretBasic turretBasic) {
		if (turretBasic is StandardTurret standardTurret) { return standardTurret.Data(); }
		return null;
	}

	public static TurretData Data(this StandardTurret template) {
		TurretData turretData = new TurretData();

		turretData.range = template.range;

		return turretData;
	}
}

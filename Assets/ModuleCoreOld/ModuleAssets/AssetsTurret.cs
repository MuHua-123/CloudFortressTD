using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsTurretOld : ModuleAssets<DataTurretOld> {
	/// <summary> 炮塔 可视化内容生成模块 </summary>
	public ModuleVisualOld<DataTurretOld> VisualTurret => ModuleCore.VisualTurret;

	public override void Add(DataTurretOld turret) {
		base.Add(turret);
		VisualTurret.UpdateVisual(turret);
	}
	public override void Remove(DataTurretOld turret) {
		base.Remove(turret);
		VisualTurret.ReleaseVisual(turret);
	}
}

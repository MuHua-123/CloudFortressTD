using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsTurret : ModuleAssets<DataTurret> {
    /// <summary> 炮塔 可视化内容生成模块 </summary>
    public ModuleVisualOld<DataTurret> VisualTurret => ModuleCore.VisualTurret;

    public override void Add(DataTurret turret) {
        base.Add(turret);
        VisualTurret.UpdateVisual(turret);
    }
    public override void Remove(DataTurret turret) {
        base.Remove(turret);
        VisualTurret.ReleaseVisual(turret);
    }
}

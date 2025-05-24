using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualBullet : ModuleFixed, ModuleVisualOld<DataBullet> {

    public void Awake() => ModuleCore.VisualBullet = this;

    public void UpdateVisual(DataBullet bullet) {
        ModuleVisualTool.Create(ref bullet.visual, bullet.prefab, transform);
        bullet.visual.UpdateVisual(bullet);
    }
    public void ReleaseVisual(DataBullet bullet) {
        if (bullet.visual != null) { Destroy(bullet.visual.gameObject); }
    }
}

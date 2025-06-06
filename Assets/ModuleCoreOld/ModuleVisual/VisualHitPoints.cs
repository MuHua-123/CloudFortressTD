using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualHitPoints : ModuleFixed, ModuleVisualOld<DataMonsterOld> {
    public Transform parent;
    public Transform hitPoints;

    public void Awake() => ModuleCore.VisualHitPoints = this;

    public void UpdateVisual(DataMonsterOld monster) {
        ModuleVisualTool.Create(ref monster.hitPoints, hitPoints, parent);
        monster.hitPoints.UpdateVisual(monster);
    }
    public void ReleaseVisual(DataMonsterOld monster) {
        if (monster.hitPoints == null) { return; }
        Destroy(monster.hitPoints.gameObject);
        monster.hitPoints = null;
    }
}

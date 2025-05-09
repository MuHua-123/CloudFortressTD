using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualHitPoints : ModuleFixed, ModuleVisual<DataMonster> {
    public Transform parent;
    public Transform hitPoints;

    public void Awake() => ModuleCore.VisualHitPoints = this;

    public void UpdateVisual(DataMonster monster) {
        ModuleVisualTool.Create(ref monster.hitPoints, hitPoints, parent);
        monster.hitPoints.UpdateVisual(monster);
    }
    public void ReleaseVisual(DataMonster monster) {
        if (monster.hitPoints == null) { return; }
        Destroy(monster.hitPoints.gameObject);
        monster.hitPoints = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualMonster : ModuleFixed, ModuleVisual<DataMonster> {

    public void Awake() => ModuleCore.VisualMonster = this;

    public void UpdateVisual(DataMonster monster) {
        ModuleVisualTool.Create(ref monster.visual, monster.Prefab, transform);
        monster.visual.UpdateVisual(monster);
    }
    public void ReleaseVisual(DataMonster monster) {
        if (monster.visual != null) { Destroy(monster.visual.gameObject); }
    }
}

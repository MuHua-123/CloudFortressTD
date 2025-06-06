using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualMonster : ModuleFixed, ModuleVisualOld<DataMonsterOld> {

    public void Awake() => ModuleCore.VisualMonster = this;

    public void UpdateVisual(DataMonsterOld monster) {
        ModuleVisualTool.Create(ref monster.visual, monster.Prefab, transform);
        monster.visual.UpdateVisual(monster);
    }
    public void ReleaseVisual(DataMonsterOld monster) {
        if (monster.visual != null) { Destroy(monster.visual.gameObject); }
    }
}

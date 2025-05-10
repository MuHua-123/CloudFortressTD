using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物生产倒计时
/// </summary>
public class VisualMonsterSpawn : ModuleFixed, ModuleVisualOld<FixedMonsterSpawn> {
    public Transform parent;
    public Transform spawnCountdown;

    public void Awake() => ModuleCore.VisualMonsterSpawn = this;

    public void UpdateVisual(FixedMonsterSpawn spawn) {
        ModuleVisualTool.Create(ref spawn.visual, spawnCountdown, parent);
        spawn.visual.UpdateVisual(spawn);
    }
    public void ReleaseVisual(FixedMonsterSpawn spawn) {
        if (spawn.visual != null) { Destroy(spawn.visual.gameObject); }
    }
}

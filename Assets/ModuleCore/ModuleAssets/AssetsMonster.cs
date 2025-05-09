using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 
/// 管理怪物数据
/// </summary>
public class AssetsMonster : ModuleAssets<DataMonster> {
    public override event Action OnChange;

    /// <summary> 怪物 可视化内容生成模块 </summary>
    public ModuleVisual<DataMonster> VisualMonster => ModuleCore.VisualMonster;
    /// <summary> 生命值 可视化内容生成模块 </summary>
    public ModuleVisual<DataMonster> VisualHitPoints => ModuleCore.VisualHitPoints;

    public override void Add(DataMonster monster) {
        if (Datas.Contains(monster)) { return; }
        Datas.Add(monster);
        OnChange?.Invoke();
        VisualMonster.UpdateVisual(monster);
        VisualHitPoints.UpdateVisual(monster);
    }
    public override void Remove(DataMonster monster) {
        if (!Datas.Contains(monster)) { return; }
        Datas.Remove(monster);
        OnChange?.Invoke();
        VisualMonster.ReleaseVisual(monster);
        VisualHitPoints.ReleaseVisual(monster);
    }
}

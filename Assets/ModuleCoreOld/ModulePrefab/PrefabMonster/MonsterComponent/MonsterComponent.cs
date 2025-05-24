using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物组件
/// </summary>
public abstract class MonsterComponent : MonoBehaviour {
    /// <summary> 核心模块 </summary>
    protected virtual ModuleCore ModuleCore => ModuleCore.I;

    /// <summary> 初始化组件 </summary>
    public abstract void Initialize(PrefabMonster prefabMonster);
    /// <summary> 更新组件 </summary>
    public virtual void UpdateVisual() { }
}

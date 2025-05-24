using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 卡牌数据
/// </summary>
public abstract class ConstCards : ScriptableObject {
    /// <summary> 核心模块 </summary>
    protected virtual ModuleCore ModuleCore => ModuleCore.I;

    /// <summary> 图标 </summary>
    public Sprite icon;
    /// <summary> 描述 </summary>
    public abstract string Describe { get; }
    /// <summary> 选择 </summary>
    public abstract void Select();
}

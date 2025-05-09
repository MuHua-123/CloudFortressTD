using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 炮塔组件
/// </summary>
public class TurretComponent : MonoBehaviour {
    /// <summary> 核心模块 </summary>
    protected virtual ModuleCore ModuleCore => ModuleCore.I;
}

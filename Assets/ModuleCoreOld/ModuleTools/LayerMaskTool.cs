using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 图层遮罩工具
/// </summary>
public static class LayerMaskTool {
    /// <summary> 相机定位 </summary>
    public static readonly LayerMask CameraPosition = 1 << LayerMask.NameToLayer("CameraPosition");
    /// <summary> 怪物 </summary>
    public static readonly LayerMask Monster = 1 << LayerMask.NameToLayer("Monster");
}

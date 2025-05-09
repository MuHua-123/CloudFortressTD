using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 轮廓工具
/// </summary>
public class FixedOutline : ModuleFixed {
    public List<Transform> RenderObjs;

    public DataOutline To() {
        Renderer[] renderers = new Renderer[RenderObjs.Count];
        for (int i = 0; i < RenderObjs.Count; i++) {
            renderers[i] = RenderObjs[i].GetComponent<Renderer>();
        }
        DataOutline outline = new DataOutline();
        outline.RenderObjs = renderers;
        return outline;
    }
}

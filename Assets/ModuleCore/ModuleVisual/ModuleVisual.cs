using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 可视化内容生成模块
/// </summary>
public interface ModuleVisual<Data> {
    /// <summary> 更新可视化内容 </summary>
    public void UpdateVisual(Data data);
    /// <summary> 释放可视化内容 </summary>
    public void ReleaseVisual(Data data);
}
/// <summary>
/// 可视化内容生成模块工具
/// </summary>
public static class ModuleVisualTool {
    /// <summary> 创建可视化内容 </summary>
    public static void Create<T>(ref T value, Transform original, Transform parent) where T : MonoBehaviour {
        if (value != null && value.gameObject != null) { return; }
        Transform temp = CreateTransform(original, parent);
        value = temp.GetComponent<T>();
    }
    public static Transform CreateTransform(Transform original, Transform parent) {
        Transform temp = Transform.Instantiate(original, parent);
        temp.gameObject.SetActive(true);
        return temp;
    }
}

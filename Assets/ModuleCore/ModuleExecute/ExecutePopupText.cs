using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弹出文本数据
/// </summary>
public class DataPopupText {
    /// <summary> 持续时间 </summary>
    public float duration;
    /// <summary> 内容 </summary>
    public string content;
    /// <summary> 位置 </summary>
    public Vector3 position;
}
/// <summary>
/// 弹出文本 执行模块
/// </summary>
public class ExecutePopupText : ModuleFixed, ModuleExecute<DataPopupText> {
    public Transform parent;
    public Transform damageText;

    public void Awake() => ModuleCore.ExecutePopupText = this;

    public void Execute(DataPopupText popupText) {
        Transform temp = Instantiate(damageText, parent);
        temp.gameObject.SetActive(true);
        ModulePrefab<DataPopupText> prefab = temp.GetComponent<ModulePrefab<DataPopupText>>();
        prefab.UpdateVisual(popupText);
    }
}

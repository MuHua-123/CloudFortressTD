using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 弹出页面 - 管理器
/// </summary>
public class UIPopupManager : ModuleUIPage {
	public override VisualElement Element => root.Q<VisualElement>("Popup");
}

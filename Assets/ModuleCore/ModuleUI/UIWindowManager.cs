using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 窗口页面 - 管理器
/// </summary>
public class UIWindowManager : ModuleUIPage {
	public override VisualElement Element => root.Q<VisualElement>("Window");
}

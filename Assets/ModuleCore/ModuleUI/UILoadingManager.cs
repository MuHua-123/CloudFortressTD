using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 加载页面 - 管理器
/// </summary>
public class UILoadingManager : ModuleUIPage {
	public override VisualElement Element => root.Q<VisualElement>("Loading");
}

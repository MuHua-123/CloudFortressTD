using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 主页
/// </summary>
public class UIHomePage : ModuleUIPage {

	public override VisualElement Element => root.Q<VisualElement>("HomePage");
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 经典模式 - 选择场景
/// </summary>
public class UIClassicScene : ModuleUIPage {

	public override VisualElement Element => root.Q<VisualElement>("ClassicScene");

}

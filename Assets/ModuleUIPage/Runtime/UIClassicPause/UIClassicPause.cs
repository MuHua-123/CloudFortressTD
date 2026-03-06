using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 经典模式 - 游戏暂停
/// </summary>
public class UIClassicPause : ModuleUIPage {

	public override VisualElement Element => root.Q<VisualElement>("ClassicPause");
}

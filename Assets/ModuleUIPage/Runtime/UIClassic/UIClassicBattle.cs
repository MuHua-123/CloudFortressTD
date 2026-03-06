using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 经典模式 - 战斗场景
/// </summary>
public class UIClassicBattle : ModuleUIPage {

	public override VisualElement Element => root.Q<VisualElement>("ClassicBattle");

}

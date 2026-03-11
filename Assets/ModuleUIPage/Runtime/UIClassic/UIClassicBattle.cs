using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 经典模式 - 战斗场景
/// </summary>
public class UIClassicBattle : UIStandardPage {

	public override VisualElement Element => root.Q<VisualElement>("ClassicBattle");

	protected override void ModuleUI_OnJumpPage(Page page) {
		bool isEnable = page == Page.ClassicBattle;
		Element.EnableInClassList("document-page-hide", !isEnable);
		if (!isEnable) { return; }
		ModuleInput.Settings(InputMode.Standard);
		ModuleCamera.Settings(CameraMode.Observe);
	}
}

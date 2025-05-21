using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 战斗页面
/// </summary>
public class UIBattlePage : ModuleUIPage {

	public override VisualElement Element => root.Q<VisualElement>("BattlePage");

	private void Awake() {
		ModuleUI.OnJumpPage += ModuleUI_OnJumpPage;
	}

	private void ModuleUI_OnJumpPage(EnumPage page) {
		Element.EnableInClassList("document-page-hide", page != EnumPage.Battle);
	}
}

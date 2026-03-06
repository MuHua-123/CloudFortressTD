using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 设置页面
/// </summary>
public class UISettingsPage : UIStandardPage {

	public override VisualElement Element => root.Q<VisualElement>("SettingsPage");

	protected override void ModuleUI_OnJumpPage(Page page) {
		bool isEnable = page == Page.Settings;
		Element.EnableInClassList("document-page-hide", !isEnable);
		if (!isEnable) { return; }
	}
}

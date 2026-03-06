using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 经典模式 - 选择场景
/// </summary>
public class UIClassicScene : UIStandardPage {

	public override VisualElement Element => root.Q<VisualElement>("ClassicScene");

	protected override void ModuleUI_OnJumpPage(Page page) {
		bool isEnable = page == Page.ClassicScene;
		Element.EnableInClassList("document-page-hide", !isEnable);
		if (!isEnable) { return; }
	}
}

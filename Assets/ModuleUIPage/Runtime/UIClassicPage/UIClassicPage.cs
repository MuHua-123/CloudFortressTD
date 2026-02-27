using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 经典塔防
/// </summary>
public class UIClassicPage : UIStandardPage {

	public override VisualElement Element => root.Q<VisualElement>("ClassicPage");

	protected override void ModuleUI_OnJumpPage(Page page) {
		bool isDisable = page != Page.Classic;
		Element.EnableInClassList("document-page-hide", isDisable);
		if (isDisable) { return; }
	}
}

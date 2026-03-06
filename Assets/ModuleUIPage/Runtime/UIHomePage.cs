using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 主页
/// </summary>
public class UIHomePage : UIStandardPage {

	public override VisualElement Element => root.Q<VisualElement>("HomePage");

	public Button Button1 => Q<Button>("Button1");// 经典模式

	public override void Awake() {
		base.Awake();
		Button1.clicked += Button1_clicked;
	}
	private void Button1_clicked() {
		ModuleUI.Settings(Page.ClassicScene);
	}

	protected override void ModuleUI_OnJumpPage(Page page) {
		bool isEnable = page == Page.Home;
		Element.EnableInClassList("document-page-hide", !isEnable);
		if (!isEnable) { return; }
	}


}

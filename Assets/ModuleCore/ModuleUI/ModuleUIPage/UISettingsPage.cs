using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 游戏设置页面
/// </summary>
public class UISettingsPage : ModuleUIPage {
	public override VisualElement Element => root.Q<VisualElement>("SettingsPage");

	public VisualElement Bottom => Q<VisualElement>("Bottom");
	public Button Button1 => Bottom.Q<Button>("Button1");// 返回
	public Button Button2 => Bottom.Q<Button>("Button2");// ???
	public Button Button3 => Bottom.Q<Button>("Button3");// ???

	private void Awake() {
		Button1.clicked += () => ModuleUI.Jump(EnumPage.Menu);
		// Button2.clicked += () => { };
		// Button3.clicked += () => { };

		ModuleUI.OnJumpPage += ModuleUI_OnJumpPage;
	}

	private void ModuleUI_OnJumpPage(EnumPage page) {
		Element.EnableInClassList("document-page-hide", page != EnumPage.Settings);
	}
}

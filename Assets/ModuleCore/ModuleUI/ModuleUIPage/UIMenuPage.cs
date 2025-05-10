using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 菜单页面
/// </summary>
public class UIMenuPage : ModuleUIPage {
	public override VisualElement Element => root.Q<VisualElement>("MenuPage");

	public VisualElement Background => Q<VisualElement>("Background");
	public VisualElement Menu => Background.Q<VisualElement>("Menu");
	public Button Button1 => Menu.Q<Button>("Button1");// 开始游戏
	public Button Button2 => Menu.Q<Button>("Button2");// ???
	public Button Button3 => Menu.Q<Button>("Button3");// 游戏设置
	public Button Button4 => Menu.Q<Button>("Button4");// 退出游戏

	private void Awake() {
		Button1.clicked += () => ModuleUI.Jump(EnumPage.Scene);
		Button2.clicked += () => { };
		Button3.clicked += () => ModuleUI.Jump(EnumPage.Settings);
		Button4.clicked += () => Application.Quit();

		ModuleUI.OnJumpPage += ModuleUI_OnJumpPage;
	}

	private void ModuleUI_OnJumpPage(EnumPage page) {
		Element.EnableInClassList("document-page-hide", page != EnumPage.Menu);
	}
}

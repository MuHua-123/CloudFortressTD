using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 场景选择页面
/// </summary>
public class UIScenePage : ModuleUIPage {
	public VisualTreeAsset SceneTemplate;

	public UIScenePanel scenePanel;

	public override VisualElement Element => root.Q<VisualElement>("ScenePage");

	public VisualElement ScrollView => Q<VisualElement>("ScrollView");// 滚动视图
	public Button Button1 => Q<Button>("Button1");// 返回
	public Button Button2 => Q<Button>("Button2");// 开始游戏
	public Label SceneLabel => Q<Label>("SceneLabel");// 场景标签

	private void Awake() {
		scenePanel = new UIScenePanel(ScrollView, root, SceneTemplate, SettingsScene);

		Button1.clicked += () => ModuleUI.Jump(EnumPage.Menu);
		Button2.clicked += () => Button2_clicked();

		ModuleUI.OnJumpPage += ModuleUI_OnJumpPage;
	}
	private void OnDestroy() => scenePanel.Release();
	private void Update() => scenePanel.Update();

	private void Button2_clicked() {
		if (!AssetsScene.I.isValid) { return; }
		ModuleUI.Jump(EnumPage.Prepare);
		SingleManager.SettingsRunningMode(EnumRunningMode.Standard);
	}
	private void ModuleUI_OnJumpPage(EnumPage page) {
		Element.EnableInClassList("document-page-hide", page != EnumPage.Scene);
		if (page != EnumPage.Scene) { return; }
		SettingsScene(null);
		AssetsScene.I.UpdateSceneConfig();
	}

	/// <summary> 选中的场景配置 </summary>
	public void SettingsScene(DataScene sceneConfig) {
		AssetsScene.I.Settings(sceneConfig);
		SceneLabel.text = sceneConfig != null ? sceneConfig.name : "???";
	}

}

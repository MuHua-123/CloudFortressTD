using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;
using UnityEngine.SceneManagement;

/// <summary>
/// 游戏准备 - 页面
/// </summary>
public class UIPreparePage : ModuleUIPage {

	public VisualTreeAsset TurretCardTemplate;

	public UITurretPanel turretPanel;

	public override VisualElement Element => root.Q<VisualElement>("PreparePage");

	public VisualElement ScrollView => Q<VisualElement>("ScrollView");// 滚动视图
	public Button Button1 => Q<Button>("Button1");// 返回
	public Button Button2 => Q<Button>("Button2");// 开始游戏
	public Label SceneLabel => Q<Label>("SceneLabel");// 场景标签

	private void Awake() {
		turretPanel = new UITurretPanel(ScrollView, root, TurretCardTemplate, SettingsTurret);

		Button1.clicked += () => ModuleUI.Settings(Page.Scene);
		// Button2.clicked += () => AssetsScene.I.LoadScene(SingleManager.SwitchRunningMode);

		ModuleUI.OnJumpPage += ModuleUI_OnJumpPage;
	}
	private void OnDestroy() {
		turretPanel.Release();
	}
	private void Update() {
		turretPanel.Update();
	}

	private void ModuleUI_OnJumpPage(Page page) {
		Element.EnableInClassList("document-page-hide", page != Page.Prepare);
		if (page != Page.Prepare) { return; }
		AssetsTurret.I.useTurrets.Clear();
		AssetsTurret.I.UpdateConfig();
	}

	/// <summary> 选中炮塔 </summary>
	public void SettingsTurret(HTurret turretBasic) {
		List<HTurret> turretList = AssetsTurret.I.useTurrets;
		bool isSelected = turretList.Contains(turretBasic);
		if (isSelected) {
			turretList.Remove(turretBasic);
		}
		else if (turretList.Count < 6) {
			turretList.Add(turretBasic);
		}
		else {
			// 超过上限不做处理
			return;
		}
		turretPanel.Settings(turretBasic, !isSelected);
		SceneLabel.text = $"已选({turretList.Count}/6)";
	}

}

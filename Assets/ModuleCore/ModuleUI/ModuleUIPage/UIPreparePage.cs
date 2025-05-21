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

	public event Action<ModuleTurret, bool> OnTurretSelect;

	public VisualTreeAsset TurretCardTemplate;

	public UIScrollList<UITurretItem, ModuleTurret> turretPresets;

	public override VisualElement Element => root.Q<VisualElement>("PreparePage");

	public VisualElement ScrollView => Q<VisualElement>("ScrollView");// 滚动视图
	public Button Button1 => Q<Button>("Button1");// 返回
	public Button Button2 => Q<Button>("Button2");// 开始游戏
	public Label SceneLabel => Q<Label>("SceneLabel");// 场景标签

	private void Awake() {
		turretPresets = new UIScrollList<UITurretItem, ModuleTurret>(ScrollView, root, TurretCardTemplate,
			(data, element) => new UITurretItem(data, element, this), UIDirection.Vertical);

		Button1.clicked += () => ModuleUI.Jump(EnumPage.Scene);
		Button2.clicked += () => SingleManager.I.StartGame();

		ModuleUI.OnJumpPage += ModuleUI_OnJumpPage;
		AssetsTurretConfig.OnChange += AssetsTurretConfig_OnChange;
	}
	private void OnDestroy() => turretPresets.Release();
	private void Update() => turretPresets.Update();

	private void ModuleUI_OnJumpPage(EnumPage page) {
		Element.EnableInClassList("document-page-hide", page != EnumPage.Prepare);
		if (page != EnumPage.Prepare) { return; }
		ManagerTurret.I.turretList.Clear();
		AssetsTurretConfig.I.UpdateConfig();
	}
	private void AssetsTurretConfig_OnChange() {
		turretPresets.Create(AssetsTurretConfig.Datas);
	}

	/// <summary> 选中炮塔 </summary>
	public void SetModuleTurret(ModuleTurret turret) {
		if (ManagerTurret.I.turretList.Contains(turret)) {
			ManagerTurret.I.turretList.Remove(turret);
			OnTurretSelect?.Invoke(turret, false);
			SceneLabel.text = $"已选({ManagerTurret.I.turretList.Count}/6)";
			return;
		}
		if (ManagerTurret.I.turretList.Count < 6) {
			ManagerTurret.I.turretList.Add(turret);
			OnTurretSelect?.Invoke(turret, true);
			SceneLabel.text = $"已选({ManagerTurret.I.turretList.Count}/6)";
			return;
		}
	}

	#region UI项定义
	/// <summary>
	/// 预选炮塔 UI项
	/// </summary>
	public class UITurretItem : ModuleUIItem<ModuleTurret> {
		public readonly UIPreparePage parent;

		public Label Title => Q<Label>("Title");
		public VisualElement Image => Q<VisualElement>("Image");
		public VisualElement Background => Q<VisualElement>("Background");

		public UITurretItem(ModuleTurret value, VisualElement element, UIPreparePage parent) : base(value, element) {
			this.parent = parent;
			Title.text = value.name;
			Image.style.backgroundImage = new StyleBackground(value.icon);

			element.RegisterCallback<ClickEvent>(evt => Select());
			parent.OnTurretSelect += UIPreparePage_OnTurretSelect;
		}
		public override void Select() {
			parent.SetModuleTurret(value);
		}
		private void UIPreparePage_OnTurretSelect(ModuleTurret turret, bool arg2) {
			if (turret != value) { return; }
			Background.EnableInClassList("turret-card-bg-s", arg2);
		}
	}
	#endregion
}

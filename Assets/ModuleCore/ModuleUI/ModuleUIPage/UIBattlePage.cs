using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 战斗页面
/// </summary>
public class UIBattlePage : ModuleUIPage {

	public VisualTreeAsset TurretCardTemplate;

	public ModuleUIItems<UITurretItem, TurretBasic> turretPresets;

	public override VisualElement Element => root.Q<VisualElement>("BattlePage");

	public VisualElement Bottom => Q<VisualElement>("Bottom");// 滚动视图

	private void Awake() {
		turretPresets = new ModuleUIItems<UITurretItem, TurretBasic>(Bottom, TurretCardTemplate,
		(data, element) => new UITurretItem(data, element, this));

		ModuleUI.OnJumpPage += ModuleUI_OnJumpPage;
	}
	private void OnDestroy() {
		turretPresets.Release();
	}

	private void ModuleUI_OnJumpPage(EnumPage page) {
		Element.EnableInClassList("document-page-hide", page != EnumPage.Battle);
		if (page != EnumPage.Battle) { return; }
		turretPresets.Create(ManagerTurret.I.turretList);
	}

	/// <summary>
	/// 炮塔 UI项
	/// </summary>
	public class UITurretItem : ModuleUIItem<TurretBasic> {
		public readonly UIBattlePage parent;

		public Label Price => Q<Label>("Price");
		public VisualElement Image => Q<VisualElement>("Image");
		public VisualElement Background => Q<VisualElement>("Background");

		public UITurretItem(TurretBasic value, VisualElement element, UIBattlePage parent) : base(value, element) {
			this.parent = parent;
			Price.text = $"${value.buildValue}";
			Image.style.backgroundImage = new StyleBackground(value.icon);

			element.RegisterCallback<ClickEvent>(evt => Select());
		}
		public override void DefaultState() {
			Background.EnableInClassList("battlepage-card-bg-s", false);
		}
		public override void SelectState() {
			Background.EnableInClassList("battlepage-card-bg-s", true);
		}
	}
}

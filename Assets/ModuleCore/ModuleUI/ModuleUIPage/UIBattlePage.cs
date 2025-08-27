using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 战斗页面
/// </summary>
public class UIBattlePage : ModuleUIPage {

	public VisualTreeAsset TurretTemplate;

	public UIBattleValue battleValue;
	public UIBattleCount battleCount;
	public UIBattleButtons battleButtons;
	public UITurretContainerPanel turretContainer;

	public override VisualElement Element => root.Q<VisualElement>("BattlePage");

	public VisualElement Top => Q<VisualElement>("Top");
	public VisualElement Value => Top.Q<VisualElement>("Value");
	public VisualElement Count => Top.Q<VisualElement>("Count");
	public VisualElement Buttons => Top.Q<VisualElement>("Buttons");
	public VisualElement TurretContainer => Q<VisualElement>("TurretContainer");

	private void Awake() {
		battleValue = new UIBattleValue(Value);
		battleCount = new UIBattleCount(Count);
		battleButtons = new UIBattleButtons(Buttons);
		turretContainer = new UITurretContainerPanel(TurretContainer, TurretTemplate);

		ModuleUI.OnJumpPage += ModuleUI_OnJumpPage;
	}
	private void OnDestroy() {
		turretContainer.Release();
	}
	private void Update() {
		battleValue.Update();
		battleCount.Update();
	}

	private void ModuleUI_OnJumpPage(EnumPage page) {
		Element.EnableInClassList("document-page-hide", page != EnumPage.Battle);
		if (page != EnumPage.Battle) { return; }
		turretContainer.UpdatePanel();
		battleButtons.ChangeButtonState();
	}
}
/// <summary>
/// 战斗值面板
/// </summary>
public class UIBattleValue : ModuleUIPanel {
	public Label HealthValue => Q<Label>("HealthValue");
	public Label MoneyValue => Q<Label>("MoneyValue");

	public UIBattleValue(VisualElement element) : base(element) { }

	public void Update() {
		HealthValue.text = ManagerBattle.I.health.ToString();
		MoneyValue.text = ManagerBattle.I.gold.ToString();
	}
}
/// <summary>
/// 战斗计数面板
/// </summary>
public class UIBattleCount : ModuleUIPanel {
	public Label Wave => Q<Label>("Wave");
	public Label Countdown => Q<Label>("Countdown");

	public UIBattleCount(VisualElement element) : base(element) { }

	public void Update() {
		Wave.text = $"波次 {ManagerBattle.I.wave.x}/{ManagerBattle.I.wave.y}";
		Countdown.text = $"倒计时: {ManagerBattle.I.countdown:F0}";
	}
}
/// <summary>
/// 战斗按钮面板
/// </summary>
public class UIBattleButtons : ModuleUIPanel {
	public VisualElement Button1 => Q<VisualElement>("Button1");
	public VisualElement Button2 => Q<VisualElement>("Button2");
	public VisualElement Button3 => Q<VisualElement>("Button3");
	public VisualElement Button4 => Q<VisualElement>("Button4");

	public UIBattleButtons(VisualElement element) : base(element) {
		// Button1.clicked += () => { ModuleUI.Jump(EnumPage.Settings); };
		Button2.RegisterCallback<ClickEvent>(evt => SettingsGameSpeed(2));
		Button3.RegisterCallback<ClickEvent>(evt => SettingsGameSpeed(1));
		Button4.RegisterCallback<ClickEvent>(evt => SettingsGameSpeed(0));
		ChangeButtonState();
	}

	/// <summary> 设置游戏速度 </summary>
	public void SettingsGameSpeed(int speed) {
		ManagerBattle.GameSpeed = speed;
		ChangeButtonState();
	}
	/// <summary> 关闭按钮状态 </summary>
	public void ChangeButtonState() {
		Button4.Q<VisualElement>("Iamge").EnableInClassList("battle-button-s", ManagerBattle.GameSpeed == 0);
		Button3.Q<VisualElement>("Iamge").EnableInClassList("battle-button-s", ManagerBattle.GameSpeed == 1);
		Button2.Q<VisualElement>("Iamge").EnableInClassList("battle-button-s", ManagerBattle.GameSpeed == 2);
	}
}
/// <summary>
/// 炮台容器面板
/// </summary>
public class UITurretContainerPanel : ModuleUIPanel {

	public ModuleUIItems<UITurretItem, HTurret> turretPresets;

	public VisualElement Container => Q<VisualElement>("Container");

	public UITurretContainerPanel(VisualElement element, VisualTreeAsset TurretTemplate) : base(element) {
		turretPresets = new ModuleUIItems<UITurretItem, HTurret>(Container, TurretTemplate,
				(data, element) => new UITurretItem(data, element, this));
	}

	public void Release() => turretPresets.Dispose();

	public void UpdatePanel() => turretPresets.Create(AssetsTurret.I.useTurrets);

	/// <summary>
	/// 炮塔 UI项
	/// </summary>
	public class UITurretItem : ModuleUIItem<HTurret> {
		public readonly UITurretContainerPanel parent;

		public Label Price => Q<Label>("Price");
		public VisualElement Image => Q<VisualElement>("Image");
		public VisualElement Background => Q<VisualElement>("Background");

		public UITurretItem(HTurret value, VisualElement element, UITurretContainerPanel parent) : base(value, element) {
			this.parent = parent;
			Price.text = $"${value.buildValue}";
			Image.style.backgroundImage = new StyleBackground(value.icon);

			element.RegisterCallback<ClickEvent>(evt => Select());
		}
		public override void DefaultState() {
			Background.EnableInClassList("battlepage-card-bg-s", false);
		}
		public override void SelectState() {
			ModuleInput.I.EnablePreview(value, DefaultState);
			Background.EnableInClassList("battlepage-card-bg-s", true);
		}
	}
}
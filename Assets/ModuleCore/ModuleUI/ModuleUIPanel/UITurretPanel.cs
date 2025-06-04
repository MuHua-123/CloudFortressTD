using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 炮塔面板
/// </summary>
public class UITurretPanel : ModuleUIPanel {

	public Action<HTurret> callback;
	public event Action<HTurret, bool> OnSelect;

	public UIScrollList<UITurretItem, HTurret> ScrollList;

	public UITurretPanel(VisualElement element, VisualElement canvas, VisualTreeAsset templateAsset, Action<HTurret> callback) : base(element) {
		this.callback = callback;

		ScrollList = new UIScrollList<UITurretItem, HTurret>(element, canvas, templateAsset,
			(data, element) => new UITurretItem(data, element, this), UIDirection.Vertical);

		AssetsTurret.OnChange += AssetsTurretConfig_OnChange;
	}
	public void Release() {
		ScrollList.Release();
		AssetsTurret.OnChange -= AssetsTurretConfig_OnChange;
	}
	public void Update() {
		ScrollList.Update();
	}

	private void AssetsTurretConfig_OnChange() {
		ScrollList.Create(AssetsTurret.I.turrets);
	}

	/// <summary> 设置 </summary>
	public void Settings(HTurret turretBasic) {
		callback?.Invoke(turretBasic);
	}
	/// <summary> 设置事件 </summary>
	public void Settings(HTurret turretBasic, bool isSelect) {
		OnSelect?.Invoke(turretBasic, isSelect);
	}

	#region UI项定义
	/// <summary>
	/// 预选炮塔 UI项
	/// </summary>
	public class UITurretItem : ModuleUIItem<HTurret> {
		public readonly UITurretPanel parent;

		public Label Title => Q<Label>("Title");
		public VisualElement Image => Q<VisualElement>("Image");
		public VisualElement Background => Q<VisualElement>("Background");

		public UITurretItem(HTurret value, VisualElement element, UITurretPanel parent) : base(value, element) {
			this.parent = parent;
			Title.text = value.name;
			Image.style.backgroundImage = new StyleBackground(value.icon);

			element.RegisterCallback<ClickEvent>(evt => Select());
			parent.OnSelect += UIPreparePage_OnSelect;
		}
		public override void Release() {
			base.Release();
			parent.OnSelect -= UIPreparePage_OnSelect;
		}
		public override void Select() {
			parent.Settings(value);
		}
		private void UIPreparePage_OnSelect(HTurret turret, bool arg2) {
			if (turret != value) { return; }
			Background.EnableInClassList("preparepage-card-bg-s", arg2);
		}
	}
	#endregion
}

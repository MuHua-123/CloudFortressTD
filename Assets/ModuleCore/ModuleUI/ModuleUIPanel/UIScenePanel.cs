using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 场景面板
/// </summary>
public class UIScenePanel : ModuleUIPanel {

	public Action<DataScene> callback;
	public UIScrollViewListV<UISceneItem, DataScene> ScrollList;

	public UIScenePanel(VisualElement element, VisualElement canvas, VisualTreeAsset templateAsset, Action<DataScene> callback) : base(element) {
		this.callback = callback;

		ScrollList = new UIScrollViewListV<UISceneItem, DataScene>(element, canvas, templateAsset,
			(data, element) => new UISceneItem(data, element, this));

		AssetsScene.OnChangeConfig += AssetsSceneConfig_OnChangeConfig;
	}
	public void Release() {
		ScrollList.Release();
		AssetsScene.OnChangeConfig -= AssetsSceneConfig_OnChangeConfig;
	}
	public void Update() {
		ScrollList.Update();
	}

	/// <summary> 绑定事件 </summary>
	private void AssetsSceneConfig_OnChangeConfig() {
		ScrollList.Create(AssetsScene.I.dataScenes);
	}

	/// <summary> 设置 </summary>
	public void Settings(DataScene dataScene) {
		callback?.Invoke(dataScene);
	}

	#region UI项定义
	/// <summary>
	/// 模组 UI项
	/// </summary>
	public class UISceneItem : ModuleUIItem<DataScene> {
		public readonly UIScenePanel parent;

		public Label Title => Q<Label>("Title");
		public VisualElement Image => Q<VisualElement>("Image");

		public UISceneItem(DataScene value, VisualElement element, UIScenePanel parent) : base(value, element) {
			this.parent = parent;
			Title.text = value.name;
			Image.RegisterCallback<ClickEvent>(evt => Select());
		}
		public override void DefaultState() {
			Image.EnableInClassList("scenepage-card-s", false);
		}
		public override void SelectState() {
			parent.Settings(value);
			Image.EnableInClassList("scenepage-card-s", true);
		}
	}
	#endregion
}

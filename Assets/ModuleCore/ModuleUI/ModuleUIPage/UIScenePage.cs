using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 场景选择页面
/// </summary>
public class UIScenePage : ModuleUIPage {
	public VisualTreeAsset SceneCardTemplate;

	public UIScrollList<UISceneConfigItem, DataSceneConfig> scrollList;

	public override VisualElement Element => root.Q<VisualElement>("ScenePage");

	public VisualElement ScrollView => Q<VisualElement>("ScrollView");// 滚动视图
	public Button Button1 => Q<Button>("Button1");// 返回
	public Button Button2 => Q<Button>("Button2");// 开始游戏
	public Label SceneLabel => Q<Label>("SceneLabel");// 场景标签

	private void Awake() {
		scrollList = new UIScrollList<UISceneConfigItem, DataSceneConfig>(ScrollView, root, SceneCardTemplate,
			(data, element) => new UISceneConfigItem(data, element, this), UIDirection.Horizontal);

		Button1.clicked += () => ModuleUI.Jump(EnumPage.Menu);
		Button2.clicked += () => Button2_clicked();

		ModuleUI.OnJumpPage += ModuleUI_OnJumpPage;
		AssetsSceneConfig.OnChange += AssetsSceneConfig_OnChange;
	}
	private void OnDestroy() => scrollList.Release();
	private void Update() => scrollList.Update();

	private void Button2_clicked() {
		if (!ManagerScene.isValid) { return; }
		ModuleUI.Jump(EnumPage.Prepare);
		SingleManager.SetRunningMode(EnumRunningMode.Standard);
	}
	private void ModuleUI_OnJumpPage(EnumPage page) {
		Element.EnableInClassList("document-page-hide", page != EnumPage.Scene);
		if (page != EnumPage.Scene) { return; }
		SetSceneConfig(null);
		AssetsSceneConfig.I.UpdateConfig();
	}
	private void AssetsSceneConfig_OnChange() {
		scrollList.Create(AssetsSceneConfig.Datas);
	}

	/// <summary> 选中的场景配置 </summary>
	public void SetSceneConfig(DataSceneConfig sceneConfig) {
		ManagerScene.SetSceneConfig(sceneConfig);
		SceneLabel.text = sceneConfig != null ? sceneConfig.name : "???";
	}

	#region UI项定义
	/// <summary>
	/// 模组 UI项
	/// </summary>
	public class UISceneConfigItem : ModuleUIItem<DataSceneConfig> {
		public readonly UIScenePage parent;

		public Label Title => Q<Label>("Title");
		public VisualElement Image => Q<VisualElement>("Image");

		public UISceneConfigItem(DataSceneConfig value, VisualElement element, UIScenePage parent) : base(value, element) {
			this.parent = parent;
			Title.text = value.name;
			Image.RegisterCallback<ClickEvent>(evt => Select());
		}
		public override void DefaultState() {
			Image.EnableInClassList("template-scenecard-s", false);
		}
		public override void SelectState() {
			parent.SetSceneConfig(value);
			Image.EnableInClassList("template-scenecard-s", true);
		}
	}
	#endregion
}

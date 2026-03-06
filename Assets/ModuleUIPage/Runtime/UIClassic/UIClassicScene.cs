using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 经典模式 - 选择场景
/// </summary>
public class UIClassicScene : UIStandardPage {
	/// <summary> 场景模板 </summary>
	public VisualTreeAsset SceneTemplate;
	/// <summary> 放置模板 </summary>
	public VisualTreeAsset PlaceTemplate;

	private SceneData sceneData;
	private ModuleUIItems<UIScene, SceneData> SceneDatas;

	public override VisualElement Element => root.Q<VisualElement>("ClassicScene");

	public Label SceneName => Q<Label>("SceneName");
	public Button Button1 => Q<Button>("Button1");// 返回
	public Button Button2 => Q<Button>("Button2");// 开始
	public VisualElement Container1 => Q<VisualElement>("Container1");

	public override void Awake() {
		base.Awake();

		SceneDatas = new ModuleUIItems<UIScene, SceneData>(Container1, SceneTemplate,
		(data, element) => new UIScene(data, element, this));

		Button1.clicked += Button1_clicked;
		Button2.clicked += Button2_clicked;
	}
	private void Button1_clicked() {
		ModuleUI.Settings(Page.Home);
	}
	private void Button2_clicked() {
		if (sceneData == null) { return; }
		SceneSystem.Load(sceneData, () => ModuleUI.Settings(Page.ClassicBattle));
	}

	protected override void ModuleUI_OnJumpPage(Page page) {
		bool isEnable = page == Page.ClassicScene;
		Element.EnableInClassList("document-page-hide", !isEnable);
		if (!isEnable) { return; }
		sceneData = null;
		SceneDatas.Create(AssetsManager.I.classicSceneData);
	}

	/// <summary> 设置场景 </summary>
	public void Settings(SceneData sceneData) {
		this.sceneData = sceneData;
		SceneName.text = sceneData.name;
	}

	/// <summary>
	/// 场景数据 - UI项
	/// </summary>
	public class UIScene : ModuleUIItem<SceneData> {

		public readonly UIClassicScene parent;

		public Label Name => Q<Label>("Name");
		public VisualElement Image => Q<VisualElement>("Image");

		public UIScene(SceneData value, VisualElement element, UIClassicScene parent) : base(value, element) {
			this.parent = parent;
			Name.text = value.name;
			Image.style.backgroundImage = new StyleBackground(value.preview);
			element.RegisterCallback<ClickEvent>(evt => Select());
		}
		public override void DefaultState() {
			Image.EnableInClassList("", false);
		}
		public override void SelectState() {
			Image.EnableInClassList("", true);
			parent.Settings(value);
		}
	}
}

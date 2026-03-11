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

	private UIButton1 back;
	private UIButton1 next;
	private SceneData sceneData;
	private UIScrollViewListV<UIScene, SceneData> SceneDatas;

	public override VisualElement Element => root.Q<VisualElement>("ClassicScene");

	public Label SceneName => Q<Label>("SceneName");
	public VisualElement Back => Q<VisualElement>("Back");// 返回
	public VisualElement Next => Q<VisualElement>("Next");// 开始
	public VisualElement SceneList => Q<VisualElement>("SceneList");

	public override void Awake() {
		base.Awake();

		back = new UIButton1(Back, "返回", Button1_clicked);
		next = new UIButton1(Next, "开始游戏", Button2_clicked);

		SceneDatas = new UIScrollViewListV<UIScene, SceneData>(SceneList, Element, SceneTemplate,
		(data, element) => new UIScene(data, element, this));
	}
	private void Button1_clicked() {
		ModuleUI.Settings(Page.Home);
	}
	private void Button2_clicked() {
		if (sceneData == null) { return; }
		SceneSystem.Load(sceneData, () => ModuleUI.Settings(Page.ClassicBattle));
	}

	private void Update() {
		SceneDatas.Update();
		SceneDatas.ForEach(obj => obj.Update());
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

		private float time;

		public Label Title => Q<Label>("Title");
		public VisualElement Image => Q<VisualElement>("Image");
		public VisualElement Frame => Q<VisualElement>("Frame");

		public UIScene(SceneData value, VisualElement element, UIClassicScene parent) : base(value, element) {
			this.parent = parent;
			Title.text = value.name;
			Image.style.backgroundImage = new StyleBackground(value.preview);
			Image.RegisterCallback<ClickEvent>(evt => Select());
		}
		public override void DefaultState() {
			Frame.EnableInClassList("scene-frame-s", false);
			Image.EnableInClassList("scene-image-s", false);
		}
		public override void SelectState() {
			time = 0.1f;
			Frame.EnableInClassList("scene-frame-s", true);
			Image.EnableInClassList("scene-image-s", true);
			parent.Settings(value);
		}
		public void Update() {
			time -= Time.deltaTime;
			Frame.EnableInClassList("scene-click", time >= 0);
			Image.EnableInClassList("scene-click", time >= 0);
		}
	}
}

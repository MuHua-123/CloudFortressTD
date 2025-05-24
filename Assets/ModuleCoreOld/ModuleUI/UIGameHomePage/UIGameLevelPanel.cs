using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 关卡选择UI
/// </summary>
//public class UIGameLevelPanel : UIGameHomePanel {
//    public VisualTreeAsset LevelTemplateAsset;
//    private UILevelGrade levelGrade1;
//    private UILevelGrade levelGrade2;
//    private UILevelGrade levelGrade3;
//    private UILevelGrade levelGrade4;
//    private List<UILevel> uiLevels = new List<UILevel>();

//    public override VisualElement Element => ModuleUIPage.Q<VisualElement>("Level");

//    public Button Button1 => Element.Q<Button>("Button1");
//    public VisualElement Difficulty1 => Element.Q<VisualElement>("Difficulty1");
//    public VisualElement Difficulty2 => Element.Q<VisualElement>("Difficulty2");
//    public VisualElement Difficulty3 => Element.Q<VisualElement>("Difficulty3");
//    public VisualElement Difficulty4 => Element.Q<VisualElement>("Difficulty4");
//    public MUScrollViewVertical ScrollView => Element.Q<MUScrollViewVertical>();

//    /// <summary> 关卡 资产 </summary>
//    public ModuleAssets<ConstLevel> AssetsLevel => ModuleCore.AssetsLevel;

//    protected void Awake() {
//        Button1.clicked += () => { GameHome.Switch(GameHomeType.Menu); };
//        levelGrade1 = new UILevelGrade(Difficulty1);
//        levelGrade2 = new UILevelGrade(Difficulty2);
//        levelGrade3 = new UILevelGrade(Difficulty3);
//        levelGrade4 = new UILevelGrade(Difficulty4);
//        CreateUILevel();
//    }
//    private void OnDestroy() {
//        levelGrade1.Release();
//        levelGrade2.Release();
//        levelGrade3.Release();
//        levelGrade4.Release();
//        uiLevels.ForEach(obj => obj.Release());
//    }

//    public override void Open(GameHomeType type) {
//        Element.EnableInClassList("gh-open", type == GameHomeType.Level);
//    }
//    public void SelectLevel(ConstLevel level) {
//        levelGrade1.UpdateVisual(level.grades[0]);
//        levelGrade2.UpdateVisual(level.grades[1]);
//        levelGrade3.UpdateVisual(level.grades[2]);
//        levelGrade4.UpdateVisual(level.grades[3]);
//    }

//    #region 创建
//    private void CreateUILevel() {
//        ScrollView.ClearContainer();
//        uiLevels.ForEach(obj => obj.Release());
//        uiLevels = new List<UILevel>();
//        AssetsLevel.ForEach(CreateUILevel);
//    }
//    private void CreateUILevel(ConstLevel data) {
//        VisualElement element = LevelTemplateAsset.Instantiate();
//        UILevel level = new UILevel(data, element, this);
//        uiLevels.Add(level);
//        ScrollView.AddContainer(level.element);
//    }
//    #endregion

//    #region UI项
//    /// <summary> 关卡项 </summary>
//    public class UILevel : ModuleUIItem<ConstLevel> {
//        public readonly UIGameLevelPanel parent;
//        public Button Button => element.Q<Button>();
//        public UILevel(ConstLevel value, VisualElement element, UIGameLevelPanel parent) : base(value, element) {
//            this.parent = parent;
//            Button.text = value.name.ToString();
//            Button.clicked += Select;
//        }
//        public override void DefaultState() {
//            Button.EnableInClassList("lt-button-s", false);
//        }
//        public override void SelectState() {
//            parent.SelectLevel(value);
//            Button.EnableInClassList("lt-button-s", true);
//        }
//    }
//    /// <summary> 关卡难度 </summary>
//    public class UILevelGrade {
//        /// <summary> 选择事件 </summary>
//        public static event Action<UILevelGrade> OnSelect;
//        /// <summary> 绑定的元素 </summary>
//        public readonly VisualElement element;

//        public Label Count => element.Q<Label>("Count");
//        public void UpdateVisual(ConstLevelGrade grade) {
//            string max = grade.count.y > 0 ? $"/{grade.count.y}" : "";
//            Count.text = $"{grade.count.x}{max}";
//        }

//        /// <summary> 初始化 </summary>
//        public UILevelGrade(VisualElement element) {
//            this.element = element;
//            element.RegisterCallback<ClickEvent>(evt => OnSelect?.Invoke(this));
//            OnSelect += UILevelGrade_OnSelect;
//        }
//        /// <summary> 侦听选择事件 </summary>
//        public void UILevelGrade_OnSelect(UILevelGrade obj) {
//            element.EnableInClassList("level-unit-s", this == obj);
//        }
//        /// <summary> 释放 </summary>
//        public void Release() => OnSelect -= UILevelGrade_OnSelect;
//    }
//    #endregion
//}

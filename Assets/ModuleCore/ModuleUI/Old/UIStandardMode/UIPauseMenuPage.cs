using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 游戏暂停菜单
/// </summary>
public class UIPauseMenuPage : ModuleUIPageo {
    public override VisualElement Element => document.Q<VisualElement>("PauseMenu");
    public VisualElement BG => Element.Q<VisualElement>("BG");

    public Button Button1 => Element.Q<Button>("Button1");
    public Button Button2 => Element.Q<Button>("Button2");
    public Button Button3 => Element.Q<Button>("Button3");

    public Button Button11 => Element.Q<Button>("Button11");
    public Button Button12 => Element.Q<Button>("Button12");

    /// <summary> 游戏页面 DataGamePage 数据处理器 </summary>
    public ModuleHandle<DataGamePage> HandleGamePage => ModuleCore.HandleGamePage;

    public void Awake() {
        Button1.clicked += () => { HandleGamePage.Change(DataGamePage.StandardMode); };
        HandleGamePage.OnChange += HandleGamePage_OnChange;
    }
    private void OnDestroy() {
        HandleGamePage.OnChange -= HandleGamePage_OnChange;
    }

    private void HandleGamePage_OnChange(DataGamePage obj) {
        BG.EnableInClassList("pw-bg-open", obj == DataGamePage.PauseMenu);
    }
}

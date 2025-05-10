using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 经典模式顶部3
/// </summary>
public class UIStandardModeTop3 : ModuleUIPanel {
    public Button Button1 => element.Q<Button>("Button1");
    public Button Button2 => element.Q<Button>("Button2");
    public Button Button3 => element.Q<Button>("Button3");
    public Button Button4 => element.Q<Button>("Button4");
    public UIStandardModeTop3(VisualElement element) : base(element) {
        Button1.clicked += () => { ModuleCore.HandleGamePage.Change(DataGamePage.PauseMenu); };
        Button2.clicked += () => { SettingsPlaySpeed(2); };
        Button3.clicked += () => { SettingsPlaySpeed(1); };
        Button4.clicked += () => { SettingsPlaySpeed(0); };
        ModuleCore.HandleGameState.OnChange += HandleGameState_OnChange;
    }
    public void Release() {
        ModuleCore.HandleGameState.OnChange -= HandleGameState_OnChange;
    }

    /// <summary> 设置游戏速度 </summary>
    private void SettingsPlaySpeed(int speed) {
        ModuleCore.HandleGameState.Current.PlaySpeed = speed;
        ModuleCore.HandleGameState.Change();
    }
    private void HandleGameState_OnChange(DataGameState obj) {
        Button4.Q<VisualElement>("VisualElement").EnableInClassList("sm-button-s", obj.PlaySpeed == 0);
        Button3.Q<VisualElement>("VisualElement").EnableInClassList("sm-button-s", obj.PlaySpeed == 1);
        Button2.Q<VisualElement>("VisualElement").EnableInClassList("sm-button-s", obj.PlaySpeed == 2);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 经典模式顶部1
/// </summary>
public class UIStandardModeTop1 : ModuleUIPanel {
    public Label Waves => element.Q<Label>("Waves");
    /// <summary> 当前游戏状态 </summary>
    public DataGameState GameState => ModuleCore.HandleGameState.Current;

    public UIStandardModeTop1(VisualElement element) : base(element) {
        GameState.OnUpdateValue += GameState_OnUpdateValue;
        GameState_OnUpdateValue();
    }
    public void Release() {
        GameState.OnUpdateValue -= GameState_OnUpdateValue;
    }
    private void GameState_OnUpdateValue() {
        Waves.text = $"波次 {GameState.Level}/{GameState.MaxLevel}";
    }
}

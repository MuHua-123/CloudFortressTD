using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 经典模式顶部2
/// </summary>
public class UIStandardModeTop2 : ModuleUIPanel {
    public Label Label1 => element.Q<Label>("Label1");
    public Label Label2 => element.Q<Label>("Label2");
    public Label Label3 => element.Q<Label>("Label3");
    /// <summary> 当前游戏状态 </summary>
    public DataGameState GameState => ModuleCore.HandleGameState.Current;

    public UIStandardModeTop2(VisualElement element) : base(element) {
        GameState.OnUpdateValue += GameState_OnUpdateValue;
        GameState_OnUpdateValue();
    }
    public void Release() {
        GameState.OnUpdateValue -= GameState_OnUpdateValue;
    }
    private void GameState_OnUpdateValue() {
        Label1.text = $"{GameState.Health}";
        //Label2.text = $"{GameState.GoldCoin}";
        Label3.text = $"{GameState.GoldCoin}";
    }
}

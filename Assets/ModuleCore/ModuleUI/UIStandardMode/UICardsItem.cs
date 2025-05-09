using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 卡牌模板
/// </summary>
public class UICardsItem : OldModuleUIItem<ConstCards> {
    public Label Title => element.Q<Label>("Title");
    public Label Describe => element.Q<Label>("Describe");
    public VisualElement Image => element.Q<VisualElement>("Image");
    public UICardsItem(ConstCards value, VisualElement element) : base(value, element) {
        Title.text = value.name;
        Describe.text = value.Describe;
        Image.style.backgroundImage = new StyleBackground(value.icon);

        element.RegisterCallback<ClickEvent>(obj => Select());
    }
    public override void SelectState() {
        ModuleCore.HandleGamePage.Change(DataGamePage.StandardMode);
        value.Select();
    }
}

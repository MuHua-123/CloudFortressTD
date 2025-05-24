using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary> 
/// 炮塔替换
/// </summary>
public class UITurretReplaceItem : OldModuleUIItem<ConstTurret> {
    public Label Label => element.Q<Label>("Label");
    public Button Button => element.Q<Button>();
    public VisualElement Image => element.Q<VisualElement>("Image");

    public UITurretReplaceItem(ConstTurret value, VisualElement element, Action<ConstTurret> callback) : base(value, element) {
        Label.text = $"{value.BuildValue()}￥";
        Image.style.backgroundImage = new StyleBackground(value.icon);

        value.OnChange = () => { Label.text = $"{value.BuildValue()}￥"; };
        Button.clicked += () => { callback?.Invoke(value); };
    }
}

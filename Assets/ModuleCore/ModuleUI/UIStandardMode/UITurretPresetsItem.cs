using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary> 
/// 炮塔预设项
/// </summary>
public class UITurretPresetsItem : OldModuleUIItem<ConstTurret> {
    public Label Label => element.Q<Label>("Label");
    public Button Button => element.Q<Button>();
    public VisualElement Image => element.Q<VisualElement>("Image");

    public UITurretPresetsItem(ConstTurret value, VisualElement element) : base(value, element) {
        Label.text = $"{value.BuildValue()}￥";
        Image.style.backgroundImage = new StyleBackground(value.icon);

        value.OnChange = () => { Label.text = $"{value.BuildValue()}￥"; };
        Button.clicked += Select;
    }
    public override void SelectState() {
        ModuleCore.HandleTurretBuild.Change(value);
    }
}
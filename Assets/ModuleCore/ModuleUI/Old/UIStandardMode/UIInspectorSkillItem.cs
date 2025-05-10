using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 检查器技能
/// </summary>
public class UIInspectorSkillItem : OldModuleUIItem<ConstTurretSkill> {

    public Label Label1 => element.Q<Label>("");

    public UIInspectorSkillItem(ConstTurretSkill value, VisualElement element) : base(value, element) {
        Label1.text = $"【{value.name}】";
        Label1.style.color = value.color;
    }
}

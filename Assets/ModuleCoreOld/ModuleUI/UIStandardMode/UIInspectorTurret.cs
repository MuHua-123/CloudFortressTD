using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 炮塔检查器
/// </summary>
public class UIInspectorTurret : ModuleUIPanel {
    public VisualTreeAsset skillTemplate;
    public List<UIInspectorSkillItem> inspectorSkills = new List<UIInspectorSkillItem>();

    public VisualElement Image => element.Q<VisualElement>("Image");
    public Label Name => element.Q<Label>("Name");
    public Label Label1 => element.Q<Label>("Label1");//攻击
    public Label Label2 => element.Q<Label>("Label2");//攻速
    public Label Label3 => element.Q<Label>("Label3");//范围
    public Label Label4 => element.Q<Label>("Label4");//生命系数
    public Label Label5 => element.Q<Label>("Label5");//护甲系数
    public Label Label6 => element.Q<Label>("Label6");//护盾系数

    public VisualElement SkillContainer => element.Q<VisualElement>("SkillContainer");

    /// <summary> 炮塔 DataTurret 数据处理器 </summary>
    public ModuleHandle<DataTurret> HandleTurret => ModuleCore.HandleTurret;

    public UIInspectorTurret(VisualElement element, VisualTreeAsset skillTemplate) : base(element) {
        this.skillTemplate = skillTemplate;
        HandleTurret.OnChange += HandleTurret_OnChange;
    }
    public void Release() {
        HandleTurret.OnChange -= HandleTurret_OnChange;
    }
    private void HandleTurret_OnChange(DataTurret obj) {
        element.EnableInClassList("sm-inspector-open", obj != null);
        if (obj == null) { return; }
        Image.style.backgroundImage = new StyleBackground(obj.Icon);
        Name.text = obj.Name;

        Label1.text = $"攻击：{obj.Attack}";
        Label2.text = $"攻速：{obj.AttackSpeed}";
        Label3.text = $"范围：{obj.MinAttackRange * 100}-{obj.MaxAttackRange * 100}";
        Label4.text = $"生命系数：{obj.HpFactor}";
        Label5.text = $"护甲系数：{obj.AcFactor}";
        Label6.text = $"护盾系数：{obj.EsFactor}";

        CreateUIItemInspectorSkill(obj.skills);
    }

    private void CreateUIItemInspectorSkill(List<ConstTurretSkill> skills) {
        SkillContainer.Clear();
        inspectorSkills.ForEach(obj => obj.Release());
        inspectorSkills = new List<UIInspectorSkillItem>();
        skills.ForEach(CreateUIItemInspectorSkill);
    }
    private void CreateUIItemInspectorSkill(ConstTurretSkill skill) {
        VisualElement element = skillTemplate.Instantiate();
        UIInspectorSkillItem item = new UIInspectorSkillItem(skill, element);
        inspectorSkills.Add(item);
        SkillContainer.Add(item.element);
    }

}

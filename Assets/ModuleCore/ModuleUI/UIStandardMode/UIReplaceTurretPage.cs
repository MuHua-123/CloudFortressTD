using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 替换建造列表
/// </summary>
public class UIReplaceTurretPage : ModuleUIPageo {
    public VisualTreeAsset TurretTemplate;
    private ConstTurret turret;
    private List<UITurretReplaceItem> replaces = new List<UITurretReplaceItem>();

    public override VisualElement Element => document.Q<VisualElement>("ReplaceTurret");
    public VisualElement BG => Element.Q<VisualElement>("BG");
    public VisualElement Preview => Element.Q<VisualElement>("Preview");
    public VisualElement BuildList => Element.Q<VisualElement>("BuildList");
    public Button Cancel => Element.Q<Button>("Cancel");

    public void Awake() {
        Cancel.clicked += () => { ModuleCore.HandleGamePage.Change(DataGamePage.DrawCards); };
        ModuleCore.HandleGamePage.OnChange += HandleGamePage_OnChange;
    }
    private void OnDestroy() {
        ModuleCore.HandleGamePage.OnChange -= HandleGamePage_OnChange;
    }

    private void HandleGamePage_OnChange(DataGamePage obj) {
        BG.EnableInClassList("rt-bg-open", obj == DataGamePage.ReplaceTurret);
    }

    /// <summary> 替换炮塔列表 </summary>
    public void ReplaceTurretList(ConstTurret turret) {
        this.turret = turret;
        Preview.Clear();
        VisualElement element = TurretTemplate.Instantiate();
        UITurretReplaceItem item = new UITurretReplaceItem(turret, element, null);
        Preview.Add(item.element);

        BuildList.Clear();
        replaces.ForEach(obj => obj.Release());
        replaces = new List<UITurretReplaceItem>();
        ModuleCore.TurretBuildList.ForEach(CreateUITurretPresets);
    }
    private void CreateUITurretPresets(ConstTurret value) {
        VisualElement element = TurretTemplate.Instantiate();
        UITurretReplaceItem item = new UITurretReplaceItem(value, element, ReplaceTurret);
        replaces.Add(item);
        BuildList.Add(item.element);
    }
    private void ReplaceTurret(ConstTurret replace) {
        ModuleCore.TurretBuildList.Remove(replace);
        ModuleCore.TurretBuildList.Add(turret);
        ModuleCore.HandleGamePage.Change(DataGamePage.StandardMode);
    }
}

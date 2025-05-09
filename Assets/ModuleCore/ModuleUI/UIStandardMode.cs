using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 标准模式界面
/// </summary>
public class UIStandardMode : ModuleDocument {
    public VisualTreeAsset TurretTemplate;
    public VisualTreeAsset SkillTemplate;

    public UIStandardModeTop1 top1;
    public UIStandardModeTop2 top2;
    public UIStandardModeTop3 top3;
    public UITurretPreset turretPreset;
    public UIInspectorTurret inspectorTurret;

    private bool isPause;
    private float PlaySpeed;

    public VisualElement Top1 => Q<VisualElement>("Top1");
    public VisualElement Top2 => Q<VisualElement>("Top2");
    public VisualElement Top3 => Q<VisualElement>("Top3");
    public VisualElement TurretList => Q<VisualElement>("TurretList");
    public VisualElement InspectorTurret => Q<VisualElement>("InspectorTurret");

    protected void Awake() {
        ModuleCore.CurrentPage = this;
        ModuleCore.HandleGamePage.OnChange += HandleGamePage_OnChange;
    }
    protected void Start() {
        top1 = new UIStandardModeTop1(Top1);
        top2 = new UIStandardModeTop2(Top2);
        top3 = new UIStandardModeTop3(Top3);
        turretPreset = new UITurretPreset(TurretList, TurretTemplate);
        inspectorTurret = new UIInspectorTurret(InspectorTurret, SkillTemplate);
    }
    protected void OnDestroy() {
        top1.Release();
        top2.Release();
        top3.Release();
        inspectorTurret.Release();
        ModuleCore.HandleGamePage.OnChange -= HandleGamePage_OnChange;
    }

    private void HandleGamePage_OnChange(DataGamePage obj) {
        if (obj == DataGamePage.StandardMode && isPause) {
            isPause = false;
            ModuleCore.HandleGameState.Current.PlaySpeed = PlaySpeed;
            ModuleCore.HandleGameState.Change();
        }
        if (obj != DataGamePage.StandardMode && !isPause) {
            isPause = true;
            PlaySpeed = ModuleCore.HandleGameState.Current.PlaySpeed;
            ModuleCore.HandleGameState.Current.PlaySpeed = 0;
            ModuleCore.HandleGameState.Change();
        }
    }
}

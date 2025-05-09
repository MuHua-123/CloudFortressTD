using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 炮塔预设列表
/// </summary>
public class UITurretPreset : ModuleUIPanel {
    public VisualTreeAsset turretTemplate;

    private List<UITurretPresetsItem> turretPresetss = new List<UITurretPresetsItem>();

    /// <summary> 炮塔建造列表 </summary>
    public ModuleAssets<ConstTurret> TurretBuildList => ModuleCore.TurretBuildList;

    public UITurretPreset(VisualElement element, VisualTreeAsset turretTemplate) : base(element) {
        this.turretTemplate = turretTemplate;
        TurretBuildList.OnChange += AssetsTurretPresets_OnChange;
        AssetsTurretPresets_OnChange();
    }
    public void Release() {
        TurretBuildList.OnChange -= AssetsTurretPresets_OnChange;
    }

    private void AssetsTurretPresets_OnChange() {
        element.Clear();
        turretPresetss.ForEach(obj => obj.Release());
        turretPresetss = new List<UITurretPresetsItem>();
        TurretBuildList.ForEach(CreateUITurretPresets);
    }
    private void CreateUITurretPresets(ConstTurret presets) {
        VisualElement element = turretTemplate.Instantiate();
        UITurretPresetsItem item = new UITurretPresetsItem(presets, element);
        turretPresetss.Add(item);
        this.element.Add(item.element);
    }

}

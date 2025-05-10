using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 炮塔预设
/// </summary>
[CreateAssetMenu(fileName = "ConstTurret", menuName = "数据模块/炮塔/炮塔数据")]
public class ConstTurret : ScriptableObject {
    /// <summary> 改变数据时 </summary>
    public Action OnChange;
    /// <summary> 预览图片 </summary>
    public Sprite icon;
    /// <summary> 建造价格 </summary>
    public int buildValue;
    /// <summary> 数据文件 </summary>
    public TextAsset dataFile;
    /// <summary> 炮塔等级 </summary>
    public List<ConstTurretGrade> grades;
    /// <summary> 炮塔等级 </summary>
    public ConstTurretGrade this[int index] => grades[index];
    /// <summary> 已建造数量 </summary>
    [HideInInspector] public int Count;
    /// <summary> 基础技能 </summary>
    [HideInInspector] public List<ConstTurretSkill> skills;
}
public static class DataTurretPresetsTool {
    /// <summary> 转换数据 </summary>
    public static DataTurret To(this ConstTurret presets, DataGridMapUnit mapUnit) {
        DataTurret turret = new DataTurret(presets);
        turret.mapUnit = mapUnit;
        return turret;
    }
    /// <summary> 建造价格 </summary>
    public static int BuildValue(this ConstTurret presets) {
        return (presets.Count + 1) * presets.buildValue;
    }
    /// <summary> 建造价格 </summary>
    public static void BuildCount(this ConstTurret presets, int value) {
        presets.Count += value;
        presets.OnChange?.Invoke();
    }
}
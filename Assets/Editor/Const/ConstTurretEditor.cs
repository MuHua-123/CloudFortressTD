using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ConstTurret))]
public class ConstTurretEditor : Editor {
    private ConstTurret value;

    private void Awake() => value = target as ConstTurret;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if (GUILayout.Button("生成等级")) { GenerateTurretGrade(); }
        if (GUILayout.Button("更新等级")) { UpdateTurretGrade(); }
        if (GUILayout.Button("清除等级")) { DeleteTurretGrade(); }
    }
    /// <summary> 生成等级 </summary>
    private void GenerateTurretGrade() {
        ConstTurretGrade grade = ScriptableObject.CreateInstance<ConstTurretGrade>();
        grade.turret = value;
        value.grades.Add(grade);
        AssetDatabase.AddObjectToAsset(grade, value);
        AssetDatabase.SaveAssets();
        EditorUtility.SetDirty(grade);
        EditorUtility.SetDirty(value);
    }
    /// <summary> 生成等级 </summary>
    private void UpdateTurretGrade() {
        if (value.dataFile == null) { Debug.LogError("缺失文本数据！"); return; }
        string[] textInLines = value.dataFile.text.Split('\n');
        if (textInLines == null) { Debug.LogError("缺失文本数据！"); return; }
        for (int i = 0; i < value.grades.Count; i++) {
            string[] info = textInLines[i + 1].Split(",");
            UpdateTurretGrade(info, i);
        }
        AssetDatabase.SaveAssets();
        EditorUtility.SetDirty(value);
    }
    /// <summary> 生成等级 </summary>
    private void UpdateTurretGrade(string[] info, int index) {
        ConstTurretGrade grade = value.grades[index];
        grade.name = grade.Name = info[0];
        grade.upgradeValue = int.Parse(info[1]);
        grade.attack = int.Parse(info[2]);
        grade.attackSpeed = float.Parse(info[3]);
        grade.minAttackRange = float.Parse(info[4]);
        grade.maxAttackRange = float.Parse(info[5]);
        EditorUtility.SetDirty(grade);
    }
    /// <summary> 清除等级 </summary>
    private void DeleteTurretGrade() {
        for (int i = value.grades.Count; i-- > 0;) {
            ConstTurretGrade grade = value.grades[i];
            value.grades.Remove(grade);
            if (grade == null) { continue; }
            Undo.DestroyObjectImmediate(grade);
        }
        AssetDatabase.SaveAssets();
    }
}

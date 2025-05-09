using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ConstTurretGrade))]
public class ConstTurretGradeEditor : Editor {
    private ConstTurretGrade value;

    private void Awake() => value = target as ConstTurretGrade;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if (value.name != value.Name && value.Name != null) {
            value.name = value.Name;
            AssetDatabase.SaveAssets();
            EditorUtility.SetDirty(value);
        }
        if (GUILayout.Button("清除等级")) { DeleteTurretGrade(); }
    }
    /// <summary> 清除等级 </summary>
    private void DeleteTurretGrade() {
        value.turret.grades.Remove(value);
        Undo.DestroyObjectImmediate(value);
        AssetDatabase.SaveAssets();
    }
}

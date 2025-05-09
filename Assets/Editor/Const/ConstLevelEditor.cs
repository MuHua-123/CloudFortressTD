using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ConstLevel))]
public class ConstLevelEditor : Editor {
    private ConstLevel value;

    private void Awake() => value = target as ConstLevel;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if (GUILayout.Button("生成等级")) { GenerateGrade(); }
        if (GUILayout.Button("清除等级")) { DeleteGrade(); }
    }
    /// <summary> 生成等级 </summary>
    private void GenerateGrade() {
        DeleteGrade();
        GenerateGrade("1简单");
        GenerateGrade("2普通");
        GenerateGrade("3困难");
        GenerateGrade("4无限");

        AssetDatabase.SaveAssets();
        EditorUtility.SetDirty(value);
    }
    /// <summary> 生成等级 </summary>
    private void GenerateGrade(string name) {
        ConstLevelGrade grade = ScriptableObject.CreateInstance<ConstLevelGrade>();
        grade.name = name;

        value.grades.Add(grade);
        AssetDatabase.AddObjectToAsset(grade, value);
        EditorUtility.SetDirty(grade);
    }
    /// <summary> 清除等级 </summary>
    private void DeleteGrade() {
        for (int i = value.grades.Count; i-- > 0;) {
            ConstLevelGrade grade = value.grades[i];
            value.grades.Remove(grade);
            if (grade == null) { continue; }
            Undo.DestroyObjectImmediate(grade);
        }
        AssetDatabase.SaveAssets();
    }
}

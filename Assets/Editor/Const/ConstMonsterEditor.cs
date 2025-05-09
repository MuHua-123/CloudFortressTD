using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ConstMonster))]
public class ConstMonsterEditor : Editor {
    private ConstMonster value;

    private void Awake() => value = target as ConstMonster;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if (GUILayout.Button("生成等级")) { GenerateMonsterGrade(); }
        if (GUILayout.Button("清除等级")) { DeleteMonsterGrade(); }
    }
    /// <summary> 生成等级 </summary>
    private void GenerateMonsterGrade() {
        if (value.dataFile == null) { Debug.LogError("缺失文本数据！"); return; }
        string[] textInLines = value.dataFile.text.Split('\n');
        if (textInLines == null) { Debug.LogError("缺失文本数据！"); return; }
        DeleteMonsterGrade();
        for (int i = 1; i < textInLines.Length - 1; i++) {
            string[] info = textInLines[i].Split(",");
            GenerateMonsterGrade(info);
        }
        AssetDatabase.SaveAssets();
        EditorUtility.SetDirty(value);
    }
    /// <summary> 生成等级 </summary>
    private void GenerateMonsterGrade(string[] info) {
        ConstMonsterGrade grade = ScriptableObject.CreateInstance<ConstMonsterGrade>();
        grade.monster = value;
        grade.Name = grade.name = info[0];
        grade.cost = int.Parse(info[1]);
        grade.hp = int.Parse(info[2]);
        grade.ac = int.Parse(info[3]);
        grade.es = int.Parse(info[4]);
        grade.speed = float.Parse(info[5]);

        value.grades.Add(grade);
        AssetDatabase.AddObjectToAsset(grade, value);
        EditorUtility.SetDirty(grade);
    }
    /// <summary> 清除等级 </summary>
    private void DeleteMonsterGrade() {
        for (int i = value.grades.Count; i-- > 0;) {
            ConstMonsterGrade grade = value.grades[i];
            value.grades.Remove(grade);
            if (grade == null) { continue; }
            Undo.DestroyObjectImmediate(grade);
        }
        AssetDatabase.SaveAssets();
    }
}

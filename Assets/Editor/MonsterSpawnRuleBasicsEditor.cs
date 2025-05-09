using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MonsterSpawnRuleBasics))]
public class MonsterSpawnRuleBasicsEditor : Editor {
    private MonsterSpawnRuleBasics value;

    private void Awake() => value = target as MonsterSpawnRuleBasics;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if (GUILayout.Button("生成关卡")) { GenerateMonsterSpawnUnit(); }
        if (GUILayout.Button("清除关卡")) { DeleteMonsterSpawnUnit(); }
    }
    /// <summary> 生成等级 </summary>
    private void GenerateMonsterSpawnUnit() {
        if (value.dataFile == null) { Debug.LogError("缺失文本数据！"); return; }
        string[] textInLines = value.dataFile.text.Split('\n');
        if (textInLines == null) { Debug.LogError("缺失文本数据！"); return; }
        DeleteMonsterSpawnUnit();
        for (int i = 1; i < textInLines.Length - 1; i++) {
            string[] info = textInLines[i].Split(",");
            GenerateMonsterSpawnUnit(info);
        }
        AssetDatabase.SaveAssets();
        EditorUtility.SetDirty(value);
    }
    /// <summary> 生成等级 </summary>
    private void GenerateMonsterSpawnUnit(string[] info) {
        MonsterSpawnUnit unit = ScriptableObject.CreateInstance<MonsterSpawnUnit>();
        unit.name = info[0];
        unit.maxSpawnTime = float.Parse(info[1]);
        unit.quantity = int.Parse(info[2]);
        unit.interval = float.Parse(info[3]);
        unit.strength = int.Parse(info[4]);

        value.spawnUnits.Add(unit);
        AssetDatabase.AddObjectToAsset(unit, value);
        EditorUtility.SetDirty(unit);
    }
    /// <summary> 清除等级 </summary>
    private void DeleteMonsterSpawnUnit() {
        for (int i = value.spawnUnits.Count; i-- > 0;) {
            MonsterSpawnUnit unit = value.spawnUnits[i];
            value.spawnUnits.Remove(unit);
            if (unit == null) { continue; }
            Undo.DestroyObjectImmediate(unit);
        }
        AssetDatabase.SaveAssets();
    }
}

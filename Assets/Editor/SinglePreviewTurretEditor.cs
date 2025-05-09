using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SinglePreviewTurret))]
public class SinglePreviewTurretEditor : Editor {
    private SinglePreviewTurret value;
    private void Awake() {
        value = target as SinglePreviewTurret;
    }
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if (GUILayout.Button("截图")) { value.GenerateTexture(); }
    }
}

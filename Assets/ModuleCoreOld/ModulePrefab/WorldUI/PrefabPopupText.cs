using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 预制弹出文本
/// </summary>
public class PrefabPopupText : ModulePrefab<DataPopupText> {
    public TMP_Text contentT;
    private Vector3 offset;
    public override void UpdateVisual(DataPopupText value) {
        base.UpdateVisual(value);
        contentT.text = Value.content;
        transform.LookAt(transform.position + Camera.main.transform.forward);
        Vector3 direction = (Camera.main.transform.position - Value.position).normalized;
        transform.position = Value.position + new Vector3(0, 0.1f, 0) + direction * 3;
    }
    private void Update() {
        Value.duration -= Time.deltaTime;
        transform.LookAt(transform.position + Camera.main.transform.forward);
        Vector3 direction = (Camera.main.transform.position - Value.position).normalized;
        Vector3 position = Value.position + new Vector3(0, 0.1f, 0) + direction * 3;
        offset += Vector3.up * Time.deltaTime * 0.3f;
        transform.position = position + offset;
        if (Value.duration < 0) { Destroy(gameObject); }
    }
}

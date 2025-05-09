using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedFinalPosition : ModuleFixed {
    private void OnCollisionEnter(Collision collision) {
        ModulePrefab<DataMonster> monsterPrefab = collision.gameObject.GetComponentInParent<ModulePrefab<DataMonster>>();
        if (monsterPrefab == null) { return; }
        monsterPrefab.Value.isArriveFinal = true;
    }
    private void OnCollisionExit(Collision collision) {
        ModulePrefab<DataMonster> monsterPrefab = collision.gameObject.GetComponentInParent<ModulePrefab<DataMonster>>();
        if (monsterPrefab == null) { return; }
        monsterPrefab.Value.isArriveFinal = false;
    }
}

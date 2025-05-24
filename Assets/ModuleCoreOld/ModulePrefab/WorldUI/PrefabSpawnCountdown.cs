using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrefabSpawnCountdown : ModulePrefab<FixedMonsterSpawn> {
    public TMP_Text timeT;
    private Transform follower;
    private void Update() {
        if (follower == null) { return; }
        transform.position = follower.position + new Vector3(0, 1f, 0);
        transform.LookAt(transform.position + Camera.main.transform.forward);
    }

    public override void UpdateVisual(FixedMonsterSpawn spawn) {
        base.UpdateVisual(spawn);
        follower = spawn.transform;

        if (!spawn.isValid) { return; }
        timeT.text = spawn.monsterSpawn.Countdown.ToString("0");
    }
}

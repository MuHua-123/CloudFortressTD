using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 命中道具
/// </summary>
public class TurretComponentHit : TurretComponent {
    public float time = 5f;

    private void Update() {
        if (time > 0) { time -= Time.deltaTime; return; }
        Destroy(gameObject);
    }
}

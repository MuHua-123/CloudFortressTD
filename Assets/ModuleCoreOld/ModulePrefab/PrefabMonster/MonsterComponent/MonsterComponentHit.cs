using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物被击中处理
/// </summary>
public class MonsterComponentHit : MonsterComponent {
    /// <summary> 渲染器 </summary>
    public new Renderer renderer;
    /// <summary> 渲染材质 </summary>
    public Material hpMaterial, acMaterial, esMaterial;

    private float time;
    private DataOverlap overlap;
    private PrefabMonster prefabMonster;
    private Material hp, ac, es;

    /// <summary> 最大持续时间 </summary>
    private float MaxTime => 0.1f;
    /// <summary> 怪物数据 </summary>
    private DataMonster Monster => prefabMonster.Value;

    private void Awake() {
        hp = new Material(hpMaterial);
        ac = new Material(acMaterial);
        es = new Material(esMaterial);
    }
    private void LateUpdate() {
        time -= Time.deltaTime;
        overlap.isEnable = time > 0;
    }
    private void OnDestroy() => OverlapHandle.Remove(overlap);

    public override void Initialize(PrefabMonster prefabMonster) {
        this.prefabMonster = prefabMonster;
        overlap = new DataOverlap();
        overlap.renderer = renderer;
        overlap.material = hp;
        OverlapHandle.Add(overlap);
    }
    public override void UpdateVisual() {
        time = MaxTime;
        if (Monster.es.x > 0) { overlap.material = es; return; }
        if (Monster.ac.x > 0) { overlap.material = ac; return; }
        if (Monster.hp.x > 0) { overlap.material = hp; return; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabHitPoints : ModulePrefab<DataMonster> {
    public Slider hp, ac, es;
    private Transform follower;

    public override void UpdateVisual(DataMonster monster) {
        base.UpdateVisual(monster);
        follower = monster.visual.transform;

        UpdateVisual(hp, monster.hp);
        UpdateVisual(ac, monster.ac);
        UpdateVisual(es, monster.es);
    }
    private void UpdateVisual(Slider slider, Vector2Int v2i) {
        slider.maxValue = v2i.y;
        slider.value = v2i.x;
        slider.gameObject.SetActive(v2i.x > 0);
    }

    protected void LateUpdate() {
        if (Value == null) { return; }
        UpdateVisual(hp, value.hp);
        UpdateVisual(ac, value.ac);
        UpdateVisual(es, value.es);
        if (follower == null) { return; }
        transform.position = follower.position + Value.height;
        transform.LookAt(transform.position + Camera.main.transform.forward);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabBulletLightning : PrefabBullet {
    public LineRenderer lineRenderer;
    public Transform hit;
    public float range = 1f;
    public float time = 0.05f;
    private float seed = 0.05f;
    private List<PrefabMonster> monsters = new List<PrefabMonster>();

    public LayerMask Monster => LayerMaskTool.Monster;
    public override bool IsHit => Target != null;

    public override void UpdateVisual(DataBullet value) {
        base.UpdateVisual(value);
        //攻击目标
        monsters.Add(Target);
        Vector3 position = TargetPosition;
        for (int i = 1; i < 5; i++) {
            if (!FindTarget(ref position)) { break; }
        }
        //链接
        lineRenderer.positionCount = monsters.Count + 1;
        lineRenderer.SetPosition(0, Value.position);
        for (int i = 0; i < monsters.Count; i++) {
            Vector3 hitPosition = monsters[i].body.position;
            lineRenderer.SetPosition(i + 1, hitPosition);
            //创建命中效果
            DataTemporaryProps props = new DataTemporaryProps();
            props.prefab = hit;
            props.position = hitPosition;
            ExecuteTemporaryProps.Execute(props);
            //对怪物造成伤害
            DataAttack attack = Value.To();
            attack.hitPosition = hitPosition;
            monsters[i].Damage(attack);
        }
    }
    public override void Update() {
        //释放子弹
        time -= PlaySpeed;
        seed -= PlaySpeed;
        if (seed < 0) { seed = 0.05f; lineRenderer.material.SetFloat("_Seed", Random.Range(0, 100)); }
        if (time < 0) { VisualBullet.ReleaseVisual(Value); }
    }

    private bool FindTarget(ref Vector3 position) {
        List<TargetInfo> targets = DetectionStandard.FindAllTarget(position, range, Monster);
        for (int i = 0; i < targets.Count; i++) {
            PrefabMonster monster = targets[i].target;
            if (monsters.Contains(monster)) { continue; }
            monsters.Add(monster);
            position = monster.body.position;
            return true;
        }
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabBulletStandard : PrefabBullet {
    public Transform hit;
    private bool isHit;
    private Vector3 position;
    private Vector3 direction;
    private PrefabMonster monster;

    public override bool IsHit => monster != null;

    public override void UpdateVisual(DataBullet bullet) {
        base.UpdateVisual(bullet);
        transform.position = bullet.position;
        transform.LookAt(TargetPosition);
    }

    public override void TrackTarget() {
        Vector3 dir = TargetPosition - transform.position;
        transform.position += dir.normalized * (BulletSpeed * PlaySpeed);
        transform.LookAt(TargetPosition);
    }
    public override void LostTarget() {
        transform.position += transform.forward * (BulletSpeed * PlaySpeed);
    }
    public override void HitTarget() {
        //创建命中效果
        DataTemporaryProps props = new DataTemporaryProps();
        props.prefab = hit;
        props.position = position;
        ExecuteTemporaryProps.Execute(props);
        //对怪物造成伤害
        DataAttack attack = Value.To();
        attack.hitPosition = position;
        attack.buffs.Add(new MoveSpeedBuff { time = 10, origin = Value.origin, speedFactor = 100 });
        monster.Damage(attack);
        //释放子弹
        VisualBullet.ReleaseVisual(Value);
    }

    private void OnCollisionEnter(Collision collision) {
        monster = collision.transform.GetComponentInParent<PrefabMonster>();
        if (monster == null) { return; }
        ContactPoint contactPoint = collision.GetContact(0);
        position = contactPoint.point;
        direction = contactPoint.normal * -1;
    }
}

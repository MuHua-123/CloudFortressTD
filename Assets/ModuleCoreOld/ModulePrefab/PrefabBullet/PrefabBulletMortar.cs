using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabBulletMortar : PrefabBullet {
    public Transform hit;
    public float ExplosionRange;//爆炸范围
    public float shakeAmount = 0.1f;//震动强度
    public float shakeDuration = 0.2f;//震动持续时间

    private bool isHit;
    private float flightTime;
    private Vector3 position;
    private Vector3 direction;
    private Vector3 targetPosition;
    private Vector3 launchVelocity;

    public LayerMask Monster => LayerMaskTool.Monster;
    public Vector3 FirePosition => Value.position;
    public override bool IsHit => launchVelocity.y <= 0f;
    public override float BulletSpeed => 5f;

    /// <summary> 震动相机 执行模块 </summary>
    public ModuleExecute<DataShakeCamera> ExecuteShakeCamera => ModuleCore.ExecuteShakeCamera;

    public override void UpdateVisual(DataBullet bullet) {
        base.UpdateVisual(bullet);
        transform.position = bullet.position;
    }

    public override void TrackTarget() {
        targetPosition = TargetPosition;
        LostTarget();
    }
    public override void LostTarget() {
        flightTime += PlaySpeed * BulletSpeed;
        //平面位置
        Vector3 firePlane = new Vector3(FirePosition.x, 0, FirePosition.z);
        Vector3 targetPlane = new Vector3(targetPosition.x, 0, targetPosition.z);
        //计算最高点
        float height = Vector3.Distance(firePlane, targetPlane);
        Vector3 highestPoint = targetPlane + new Vector3(0, height + FirePosition.y, 0);
        //计算方向和距离
        Vector3 finalDirection = (highestPoint - FirePosition).normalized;
        float distance = Vector3.Distance(firePlane, targetPlane) * 1.41f;
        //计算直线方向
        launchVelocity = FirePosition + finalDirection * flightTime;
        //附加垂直重力，形成抛物线
        float gravity = (FirePosition + finalDirection * distance).y;
        launchVelocity.y -= gravity * (flightTime * flightTime) / (distance * distance);

        transform.LookAt(launchVelocity);
        transform.position = launchVelocity;
    }
    public override void HitTarget() {
        launchVelocity.y = 0;
        //创建命中效果
        DataTemporaryProps props = new DataTemporaryProps();
        props.prefab = hit;
        props.position = launchVelocity;
        ExecuteTemporaryProps.Execute(props);
        //震动屏幕
        DataShakeCamera shake = new DataShakeCamera();
        shake.shakeAmount = shakeAmount;
        shake.shakeDuration = shakeDuration;
        ExecuteShakeCamera.Execute(shake);
        //对怪物造成伤害
        List<TargetInfo> targets = DetectionStandard.FindAllTarget(launchVelocity, ExplosionRange, Monster);
        targets.ForEach(HitTarget);
        //释放子弹
        VisualBullet.ReleaseVisual(Value);
    }
    public void HitTarget(TargetInfo info) {
        DataAttack attack = Value.To();
        attack.hitPosition = info.position;
        info.target.Damage(attack);
    }
}

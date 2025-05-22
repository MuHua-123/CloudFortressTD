using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 子弹 - 标准
	/// </summary>
	public class BulletStandard : Bullet {

		/// <summary> 子弹速度 </summary>
		public float bulletSpeed;
		/// <summary> 命中特效 </summary>
		public Transform hitEffect;
		/// <summary> 命中比较器 </summary>
		public Func<ITurretTarget, bool> compare;
		/// <summary> 命中目标 </summary>
		public Action<ITurretTarget, Vector3> hitTarget;
		/// <summary> 命中生成器 </summary>
		public Func<Transform, Transform> hitGenerate;

		/// <summary> 初始化 </summary>
		public void Init(Transform transform, ITurretTarget target, float bulletSpeed) {
			this.transform = transform;
			this.target = target;
			this.bulletSpeed = bulletSpeed;
		}
		/// <summary> 初始化命中 </summary>
		public void InitHit(Func<ITurretTarget, bool> compare, Action<ITurretTarget, Vector3> hitTarget) {
			this.compare = compare;
			this.hitTarget = hitTarget;
		}
		/// <summary> 初始化命中效果 </summary>
		public void InitHitEffect(Transform hitEffect, Func<Transform, Transform> hitGenerate) {
			this.hitEffect = hitEffect;
			this.hitGenerate = hitGenerate;
		}

		public override void Update() {
			if (target != null) { TrackTarget(); }
			else { LostTarget(); }
		}
		public override void OnCollisionEnter(Collision collision) {
			ITurretTarget hit = collision.transform.GetComponentInParent<ITurretTarget>();
			if (hit == null || !compare(hit)) { return; }
			ContactPoint contactPoint = collision.GetContact(0);
			hitTarget(hit, contactPoint.point);

			Transform effect = hitGenerate(hitEffect);
			effect.transform.position = contactPoint.point;
		}

		public void TrackTarget() {
			Vector3 dir = target.Position - transform.position;
			transform.position += dir.normalized * bulletSpeed * Time.deltaTime;
			transform.LookAt(target.Position);
		}
		public void LostTarget() {
			transform.position += transform.forward * bulletSpeed * Time.deltaTime;
		}
	}
}

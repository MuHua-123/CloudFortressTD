using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 侦察 - 标准
	/// </summary>
	public class DetectionStandard : TurretDetection {

		/// <summary> 侦察的范围 </summary>
		public Func<float> range;
		/// <summary> 自动侦察的间隔 </summary>
		public float interval = 0.5f;
		/// <summary> 侦察的位置 </summary>
		public Transform origin;
		/// <summary> 侦察的图层 </summary>
		public LayerMask layerMask;
		/// <summary> 比较器 </summary>
		public Func<ITurretTarget, ITurretTarget, bool> comparer;

		/// <summary> 倒计时 </summary>
		private float time;

		public DetectionStandard(Turret turret) : base(turret) { }

		public override void Update() {
			if (turret == null || interval == 0) { return; }
			time -= Time.deltaTime;
			if (time > 0) { return; }
			time = interval;
			turret.target = FindTarget();
		}

		public override ITurretTarget FindTarget() {
			if (origin == null) { return null; }
			Collider[] colliders = Physics.OverlapSphere(origin.position, range(), layerMask);
			List<ITurretTarget> turretTargets = To(colliders);

			if (turretTargets.Count == 0) { return null; }
			if (comparer == null) { return turretTargets[0]; }

			ITurretTarget target = null;
			for (int i = 0; i < turretTargets.Count; i++) {
				ITurretTarget tempTarget = turretTargets[i];
				if (comparer(tempTarget, target)) { target = tempTarget; }
			}
			return target;
		}

		public List<ITurretTarget> To(Collider[] colliders) {
			List<ITurretTarget> turretTargets = new List<ITurretTarget>();
			for (int i = 0; i < colliders.Length; i++) {
				ITurretTarget target = colliders[i].GetComponentInParent<ITurretTarget>();
				if (target != null) { turretTargets.Add(target); }
			}
			return turretTargets;
		}
	}
}
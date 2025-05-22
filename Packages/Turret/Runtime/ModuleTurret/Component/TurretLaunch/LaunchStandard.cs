using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 发射 - 标准
	/// </summary>
	public class LaunchStandard : TurretLaunch {

		/// <summary> 发射间隔 </summary>
		public Func<float> interval;
		/// <summary> 发射 </summary>
		public Action<ITurretTarget> fire;

		/// <summary> 倒计时 </summary>
		private float time;

		public LaunchStandard(Turret turret) : base(turret) { }

		public override void Update() {
			if (turret == null || interval() == 0) { return; }
			time -= Time.deltaTime;
			if (time > 0 || !turret.isLockTarget) { return; }
			time = interval();
			fire?.Invoke(turret.target);
		}
	}
}
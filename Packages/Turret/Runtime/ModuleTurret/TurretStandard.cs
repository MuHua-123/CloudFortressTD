using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 标准炮塔
	/// </summary>
	public class TurretStandard : Turret {

		/// <summary> 瞄准组件 </summary>
		public TurretAim aim;
		/// <summary> 发射组件 </summary>
		public TurretLaunch launch;
		/// <summary> 侦察组件 </summary>
		public TurretDetection detection;

		/// <summary> 初始化瞄准模块 </summary>
		public void InitAim(Transform headY, Transform headX) {
			AimStandard aim = new AimStandard(this);
			aim.headY = headY;
			aim.headX = headX;

			this.aim = aim;
		}
		/// <summary> 初始化发射模块 </summary>
		public void InitLaunch(Func<float> interval, Action<ITurretTarget> fire) {
			LaunchStandard launch = new LaunchStandard(this);
			launch.interval = interval;
			launch.fire = fire;

			this.launch = launch;
		}
		/// <summary> 初始化侦察模块 </summary>
		public void InitDetection(Transform origin, Func<float> range, LayerMask layerMask, Func<ITurretTarget, ITurretTarget, bool> comparer, float interval = 0.5f) {
			DetectionStandard detection = new DetectionStandard(this);
			detection.range = range;
			detection.interval = interval;
			detection.origin = origin;
			detection.layerMask = layerMask;
			detection.comparer = comparer;

			this.detection = detection;
		}

		public override void Update() {
			aim?.Update();
			detection?.Update();
		}
	}
}
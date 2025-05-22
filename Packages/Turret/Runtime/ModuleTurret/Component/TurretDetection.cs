using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 炮塔组件 - 侦察
	/// </summary>
	public abstract class TurretDetection {

		public readonly Turret turret;// 炮塔

		public TurretDetection(Turret turret) => this.turret = turret;

		/// <summary> 自动查找目标 </summary>
		public abstract void Update();

		/// <summary> 查找目标 </summary>
		public abstract ITurretTarget FindTarget();
	}
}
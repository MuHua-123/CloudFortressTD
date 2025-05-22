using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 炮塔组件 - 发射
	/// </summary>
	public abstract class TurretLaunch {

		public readonly Turret turret;// 炮塔

		public TurretLaunch(Turret turret) => this.turret = turret;

		/// <summary> 自动查找目标 </summary>
		public abstract void Update();

	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 炮塔组件 - 瞄准
	/// </summary>
	public abstract class TurretAim {

		public readonly Turret turret;// 炮塔

		public TurretAim(Turret turret) => this.turret = turret;

		/// <summary> 自动瞄准目标 </summary>
		public abstract void Update();

	}
}
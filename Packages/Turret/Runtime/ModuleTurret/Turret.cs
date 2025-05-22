using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 炮塔
	/// </summary>
	public abstract class Turret {

		/// <summary> 目标 </summary>
		public ITurretTarget target;
		/// <summary> 锁定目标 </summary>
		public bool isLockTarget;

		public abstract void Update();
	}
}
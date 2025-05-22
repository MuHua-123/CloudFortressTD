using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 子弹
	/// </summary>
	public abstract class Bullet {

		/// <summary> 变换 </summary>
		public Transform transform;
		/// <summary> 目标 </summary>
		public ITurretTarget target;

		public abstract void Update();

		/// <summary> 碰撞命中目标 </summary>
		public abstract void OnCollisionEnter(Collision collision);
	}
}
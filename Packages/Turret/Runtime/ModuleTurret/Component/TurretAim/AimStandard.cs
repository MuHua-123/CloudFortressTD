using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 瞄准 - 标准
	/// </summary>
	public class AimStandard : TurretAim {

		public Transform headY;
		public Transform headX;

		public AimStandard(Turret turret) : base(turret) { }

		public override void Update() {
			if (turret == null || turret.target == null) { return; }
			Vector3 position = turret.target.Position;

			Vector3 directionY = position - headY.position;
			Vector3 eulerAnglesY = Quaternion.LookRotation(directionY).eulerAngles;
			float differY = headY.eulerAngles.y - eulerAnglesY.y;
			if (differY > 180) { eulerAnglesY.y += 360; }
			if (differY < -180) { eulerAnglesY.y -= 360; }
			headY.eulerAngles = Vector3.Lerp(headY.eulerAngles, new Vector3(0, eulerAnglesY.y, 0), Time.deltaTime);
			turret.isLockTarget = Vector3.Distance(headY.eulerAngles, new Vector3(0, eulerAnglesY.y, 0)) < 10;

			Vector3 directionX = position - headX.position;
			Vector3 eulerAnglesX = Quaternion.LookRotation(directionX).eulerAngles;
			float differX = headY.eulerAngles.x - eulerAnglesY.x;
			if (differX > 180) { eulerAnglesY.x += 360; }
			if (differX < -180) { eulerAnglesY.x -= 360; }
			headX.localEulerAngles = Vector3.Lerp(headX.localEulerAngles, new Vector3(eulerAnglesX.x, 0, 0), Time.deltaTime);
		}
	}
}
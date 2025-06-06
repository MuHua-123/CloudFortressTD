using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 子弹 - 控制器
/// </summary>
public abstract class CBullet : MonoBehaviour {

	/// <summary> 初始化子弹 </summary>
	public abstract void Initial(CTurret cTurret, ITurretTarget initTarget, Transform firePoint);

	public static CBullet AddControl(HBullet hBullet) {
		if (hBullet is HBulletStandard bulletStandard) { return hBullet.gameObject.AddComponent<CBulletStandard>(); }
		return null;
	}
}

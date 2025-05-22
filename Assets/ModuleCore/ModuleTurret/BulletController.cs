using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 子弹控制器
/// </summary>
public class BulletController : MonoBehaviour {

	public Bullet bullet;
	public BulletBasic bulletBasic;

	private TurretController turretController;

	private void Update() => bullet.Update();

	/// <summary> 初始化子弹 </summary>
	public void Init(TurretController turretController, ITurretTarget initTarget) {
		this.turretController = turretController;
		bulletBasic = GetComponent<BulletBasic>();

		bullet = bulletBasic.Init(turretController, initTarget, this);
		// turretData = turretBasic.Data();
	}

	/// <summary> 命中比较器 </summary>
	public bool HitComparer(ITurretTarget hitTarget) {
		return false;
	}
	/// <summary> 命中目标 </summary>
	public void HitTarget(ITurretTarget target, Vector3 position) {
		Debug.Log($"{target} , {position}");
	}
}

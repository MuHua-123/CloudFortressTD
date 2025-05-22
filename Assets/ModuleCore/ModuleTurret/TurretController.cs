using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using MuHua;

/// <summary>
/// 炮塔控制器
/// </summary>
public class TurretController : MonoBehaviour {

	public Turret turret;
	public TurretData turretData;
	public TurretBasic turretBasic;

	private void Update() => turret.Update();

	/// <summary> 初始化炮塔 </summary>
	public void Init() {
		turretBasic = GetComponent<TurretBasic>();

		turret = turretBasic.Init(this);
		turretData = turretBasic.Data();
	}

	/// <summary> 发射子弹 </summary>
	public void LaunchBullet(Transform bulletPrefab, ITurretTarget initTarget) {
		turretBasic.animator.SetTrigger("Fire");
		Transform bullet = Transform.Instantiate(bulletPrefab);
		BulletController bulletController = bullet.AddComponent<BulletController>();
		bulletController.Init(this, initTarget);
	}
	/// <summary> 侦察比较器 </summary>
	public bool DetectionComparer(ITurretTarget ta1, ITurretTarget ta2) {
		return false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 炮塔 - 数据类
/// </summary>
public class DataTurret {

	/// <summary> 伤害 </summary>
	public int damage;
	/// <summary> 发射间隔 </summary>
	public float launchInterval;
	/// <summary> 子弹速度 </summary>
	public float bulletSpeed;

	/// <summary> 范围 </summary>
	public float range;
	/// <summary> 最小范围 </summary>
	public float minRange;
	/// <summary> 最大范围 </summary>
	public float maxRange;

	public DataTurret(HTurretStandard hTurret) {
		range = hTurret.range;
	}
	public DataTurret(HTurretStandardDual hTurret) {
		range = hTurret.range;
	}
}

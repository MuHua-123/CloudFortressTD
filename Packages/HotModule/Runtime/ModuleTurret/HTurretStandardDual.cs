using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 标准炮塔(双重发射器)
/// </summary>
public class HTurretStandardDual : HTurret {
	[Header("瞄准模块")]
	public Transform headY;// 头部Y轴
	public Transform headX;// 头部X轴
	[Header("发射模块")]
	public Transform firePoint1;// 炮口1
	public Transform firePoint2;// 炮口2
	public Transform bulletPrefab;// 炮弹预制体
	[Header("侦察模块")]
	public float range;
	public LayerMask layerMask;
}

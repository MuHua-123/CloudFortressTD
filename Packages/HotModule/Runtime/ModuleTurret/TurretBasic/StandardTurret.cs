using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 标准炮塔
/// </summary>
public class StandardTurret : TurretBasic {
	[Header("瞄准模块")]
	public Transform headY;// 头部Y轴
	public Transform headX;// 头部X轴

	[Header("发射模块")]
	public Transform firePoint;// 炮口
	public Transform bulletPrefab;// 炮弹预制体

	[Header("侦察模块")]
	public float range;
	public LayerMask layerMask;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 标准炮塔(双重发射器)
/// </summary>
public class TurretStandardDual : TurretBasic {
	[Header("炮塔组件")]
	public Transform headY;// 头部Y轴
	public Transform headX;// 头部X轴
	public Transform firePoint1;// 炮口1
	public Transform firePoint2;// 炮口2
	public Transform bulletPrefab;// 炮弹预制体
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 标准炮塔
/// </summary>
public class TurretStandard : ModuleTurret {
	[Header("炮塔组件")]
	public Transform headY;// 头部Y轴
	public Transform headX;// 头部X轴
	public Transform firePoint;// 炮口
	public Transform bulletPrefab;// 炮弹预制体
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 炮塔配置预设
/// </summary>
[CreateAssetMenu(fileName = "TurretConfig", menuName = "数据模块/炮台配置")]
public class ConstTurretConfig : ScriptableObject {
	public List<ModuleTurret> configs;
}

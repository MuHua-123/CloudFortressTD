using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 炮塔 - 管理器
/// </summary>
public class ManagerTurret : ModuleSingle<ManagerTurret> {

	public List<ModuleTurret> turretList = new List<ModuleTurret>();// 炮塔列表

	protected override void Awake() => NoReplace(false);
}

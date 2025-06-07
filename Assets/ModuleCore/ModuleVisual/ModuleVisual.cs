using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 可视化模块
/// </summary>
public class ModuleVisual : ModuleSingle<ModuleVisual> {

	/// <summary> 炮塔生成器 </summary>
	public VisualGenerator<HTurret> HTurret;
	/// <summary> 子弹生成器 </summary>
	public VisualGenerator<HBullet> HBullet;
	/// <summary> 怪物生成器 </summary>
	public VisualGenerator<HMonster> HMonster;

	protected override void Awake() => NoReplace();

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 怪物 - 控制器
/// </summary>
public abstract class CMonster : MonoBehaviour {

	public abstract void Initial();

	public static CMonster AddControl(HMonster hMonster) {
		if (hMonster is HMonsterStandard monsterStandard) { return hMonster.gameObject.AddComponent<CMonsterStandard>(); }
		return null;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 怪物 - 控制器
/// </summary>
public abstract class CMonster : MonoBehaviour {

	/// <summary> 角色模块 </summary>
	public abstract MCharacter MCharacter { get; }

	public abstract void Initial(Vector3 position, Vector3 eulerAngles, Vector3 final, Vector3 offset);

	public static CMonster AddControl(HMonster hMonster) {
		if (hMonster is HMonsterStandard standard) { return hMonster.gameObject.AddComponent<CMonsterStandard>(); }
		return null;
	}
}

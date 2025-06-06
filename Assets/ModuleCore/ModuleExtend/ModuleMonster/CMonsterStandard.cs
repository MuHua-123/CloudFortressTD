using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 标准怪物 - 控制器
/// </summary>
public class CMonsterStandard : CMonster {

	public DataMonster dMonster;
	public HMonsterStandard hMonster;
	public MCharacterStandard mMonster;

	public override void Initial() {
		hMonster = GetComponent<HMonsterStandard>();
		mMonster = new MCharacterStandard(hMonster.animator, hMonster.ground);

		dMonster = new DataMonster(hMonster);
	}

}

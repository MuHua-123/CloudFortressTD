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
	// public MCharacterStandard mMonster;

	// public override MCharacter MCharacter => mMonster;

	public override void Initial(Vector3 position, Vector3 eulerAngles, Vector3 final, Vector3 offset) {
		hMonster = GetComponent<HMonsterStandard>();
		// mMonster = new MCharacterStandard(hMonster.animator, transform, hMonster.ground);

		dMonster = new DataMonster(hMonster);

		// KPathFind pathFind = new KPathFind(mMonster, final, offset);
		// pathFind.Settings(dMonster.moveSpeed, dMonster.acceleration);
		// pathFind.Settings(position, eulerAngles);
		// mMonster.Transition(pathFind);
	}
	private void Update() {
		// mMonster.Update();
	}
	public void AnimationExit() {
		// mMonster.AnimationExit();
	}
}

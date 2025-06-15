using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物 - 数据类
/// </summary>
public class DataMonster {

	/// <summary> 移动速度 </summary>
	public float moveSpeed = 1;
	/// <summary> 加速度 </summary>
	public float acceleration = 15;

	public DataMonster(HMonsterStandard hMonster) {
		moveSpeed = hMonster.moveSpeed;
		acceleration = hMonster.acceleration;
	}

}

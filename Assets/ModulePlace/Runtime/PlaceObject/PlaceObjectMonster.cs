using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物 - 放置对象
/// </summary>
public class PlaceObjectMonster : PlaceObject {

	[Header("怪物")]
	/// <summary> 运动器 </summary>
	public CharacterMovement movement;

	/// <summary> 设置位置 </summary>
	public void Settings(Vector3 position, Vector3 eulerAngles) => movement.Settings(position, eulerAngles);
}

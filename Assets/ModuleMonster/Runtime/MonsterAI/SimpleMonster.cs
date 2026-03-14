using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  简单怪物
/// </summary>
public class SimpleMonster : MonoBehaviour {
	[Header("组件")]
	/// <summary> 运动器 </summary>
	public CharacterMovement movement;

	[Header("缓存")]
	/// <summary> 目标 </summary>
	public PlaceObjectHome home;

	private void Start() {
		if (!Utilities.FindObject(out home)) { return; }
		Vector3 v1 = home.transform.position;
		Vector3 v2 = movement.Position;
		Vector3 direction = (v1 - v2).normalized;
		movement.Move(direction);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 简单 - 运动器
/// </summary>
public class SimpleMovement : CharacterMovement {

	/// <summary> 速度 </summary>
	public float speed;
	/// <summary> 方向 </summary>
	public Vector3 direction;

	public override Vector3 Position => transform.position;

	private void Update() {
		if (direction == Vector3.zero) { return; }
		transform.position += direction * speed * Time.deltaTime;
	}

	public override void Settings(Vector3 position, Vector3 eulerAngles) {
		transform.position = position;
		transform.eulerAngles = eulerAngles;
	}
	public override void Move(Vector3 direction) {
		this.direction = direction.normalized;
	}
	public override void Jump(float jumpHeight) {
		// throw new System.NotImplementedException();
	}
	public override void Stop() {
		this.direction = Vector3.zero;
	}
}

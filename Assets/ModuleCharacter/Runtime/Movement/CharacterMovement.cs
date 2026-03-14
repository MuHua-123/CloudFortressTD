using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 运动器
/// </summary>
public abstract class CharacterMovement : MonoBehaviour {

	/// <summary> 当前位置 </summary>
	public abstract Vector3 Position { get; }

	/// <summary> 设置位置 </summary>
	public abstract void Settings(Vector3 position, Vector3 eulerAngles);
	/// <summary> 移动 </summary>
	public abstract void Move(Vector3 direction);
	/// <summary> 跳跃 </summary>
	public abstract void Jump(float jumpHeight);
	/// <summary> 停止运动 </summary>
	public abstract void Stop();
}

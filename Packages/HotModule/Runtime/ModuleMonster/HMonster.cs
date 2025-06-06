using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物 - 热更
/// </summary>
public abstract class HMonster : MonoBehaviour {
	[Header("基本属性")]
	/// <summary> 地面图层 </summary>
	public LayerMask ground;
	/// <summary> 动画器 </summary>
	public Animator animator;
}

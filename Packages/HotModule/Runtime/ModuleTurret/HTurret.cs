using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 炮塔 - 热更模块
/// </summary>
[RequireComponent(typeof(Animator))]
public abstract class HTurret : MonoBehaviour {
	[Header("基本属性")]
	/// <summary> 缩略图 </summary>
	public Sprite icon;
	/// <summary> 建造价格 </summary>
	public int buildValue;
	/// <summary> 动画器 </summary>
	public Animator animator;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 炮塔基类
/// </summary>
[RequireComponent(typeof(Animator))]
public abstract class TurretBasic : MonoBehaviour {

	[Header("基本属性")]
	public Sprite icon;// 缩略图
	public int buildValue;// 建造价格
	public Animator animator;// 动画器
}

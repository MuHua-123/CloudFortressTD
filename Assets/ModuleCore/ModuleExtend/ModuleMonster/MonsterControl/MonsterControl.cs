using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 怪物控制器
/// </summary>
public abstract class MonsterControl : MonoBehaviour, IMonsterFunc {
	[Header("怪物属性")]
	/// <summary> 移动速度 </summary>
	public float moveSpeed = 2;
	/// <summary> 冲刺速度 </summary>
	public float sprintSpeed = 5.5f;
	/// <summary> 加速度 </summary>
	public float acceleration = 15;
	/// <summary> 跳跃高度 </summary>
	public float jumpHeight = 2;

	/// <summary> 角色模块 </summary>
	public abstract CharacterModel MCharacter { get; }

	public virtual void Update() => MCharacter?.Update();

	public abstract void Initial(Vector3 position, Vector3 eulerAngles);

	public abstract void Trigger(string value);

	public abstract void SettingsState(string token, bool isTransition, bool isFloating, bool isInjured);

	/// <summary> 添加控制器 </summary>
	public static MonsterControl AddControl(MonsterHot hMonster) {
		// if (hCharacter is CharacterHotCollision collision) { return hCharacter.AddComponent<CharacterControlCollision>(); }
		// if (hCharacter is CharacterHotStandard standard) { return hCharacter.AddComponent<CharacterControlStandard>(); }
		return null;
	}
	/// <summary> 添加控制器 </summary>
	public static T AddControl<T>(MonsterHot hMonster) where T : MonsterControl {
		return hMonster.gameObject.AddComponent<T>();
	}
}

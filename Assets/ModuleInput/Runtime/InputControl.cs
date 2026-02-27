using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 输入 - 控制
/// </summary>
[RequireComponent(typeof(PlayerInput))]
public abstract class InputControl : MonoBehaviour {

	public PlayerInput Input => GetComponent<PlayerInput>();

	protected virtual void Awake() {
		ModuleInput.OnInputMode += ModuleInput_OnInputMode;
	}

	protected virtual void OnDestroy() {
		ModuleInput.OnInputMode -= ModuleInput_OnInputMode;
	}

	/// <summary> 输入模式 </summary>
	protected virtual void ModuleInput_OnInputMode(InputMode mode) { }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 创建 - 放置输入器
/// </summary>
public class PlaceInputCreate : InputControl {

	protected override void ModuleInput_OnInputMode(InputMode inputMode) {
		bool isEnable = inputMode == InputMode.Standard;
		enabled = isEnable;
		Input.enabled = isEnable;
	}

	#region 输入系统
	/// <summary> 完成 </summary>
	public void OnComplete(InputValue inputValue) {
		if (ModuleInput.IsPointerOverUIObject) { return; }
		// 创建处理
		if (inputValue.isPressed) { PlaceHandleCreate.I.Down(); }
		else { PlaceHandleCreate.I.Up(); }
	}
	/// <summary> 取消 </summary>
	public void OnCancel(InputValue inputValue) {
		PlaceHandleCreate.I.CreateCancel();
	}
	#endregion
}

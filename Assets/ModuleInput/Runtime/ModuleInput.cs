using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using MuHua;

/// <summary>
/// 输入模块
/// </summary>
public class ModuleInput : ModuleSingle<ModuleInput> {

	/// <summary> 鼠标指针位置 </summary>
	public static Vector2 mousePosition;
	/// <summary> 指针是否在UI上 </summary>
	private static bool isPointerOverUIObject;
	/// <summary> 指针是否在UI上 </summary>
	public static bool IsPointerOverUIObject => isPointerOverUIObject;

	/// <summary> 当前输入模式 </summary>
	public static InputMode inputMode;
	/// <summary> 回退输入模式 </summary>
	public static InputMode backInputMode;
	/// <summary> 转换模式事件 </summary>
	public static event Action<InputMode> OnInputMode;
	/// <summary> 设置输入模式 </summary>
	public static void Settings(InputMode mode) {
		backInputMode = inputMode;
		inputMode = mode;
		OnInputMode?.Invoke(inputMode);
	}
	/// <summary> 回退输入模式 </summary>
	public static void Back() {
		inputMode = backInputMode;
		OnInputMode?.Invoke(inputMode);
	}

	protected override void Awake() => NoReplace();

	private void Update() {
#if UNITY_STANDALONE
		//电脑平台
		isPointerOverUIObject = EventSystem.current.IsPointerOverGameObject();
#elif UNITY_WEBGL
		//WebGL平台
		isPointerOverUIObject = EventSystem.current.IsPointerOverGameObject();
#elif UNITY_ANDROID
        //安卓平台
        isPointerOverUIObject = EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
#elif UNITY_IOS
        //苹果平台
        isPointerOverUIObject = EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
#endif
	}
}
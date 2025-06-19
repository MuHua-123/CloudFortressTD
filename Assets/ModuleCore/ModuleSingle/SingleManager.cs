using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 游戏管理
/// </summary>
public class SingleManager : ModuleSingle<SingleManager> {

	/// <summary> 运行模式 </summary>
	public static EnumRunningMode runningMode;

	/// <summary> 设置运行模式 </summary>
	public static void SettingsRunningMode(EnumRunningMode runningMode) {
		SingleManager.runningMode = runningMode;
	}
	/// <summary> 切换运行模式 </summary>
	public static void SwitchRunningMode() {
		if (runningMode == EnumRunningMode.None) { EnumRunningMode_None(); }
		if (runningMode == EnumRunningMode.Standard) { EnumRunningMode_Standard(); }
	}

	protected override void Awake() => NoReplace();

	private void Start() => EnumRunningMode_None();

	/// <summary> 默认模式 </summary>
	private static void EnumRunningMode_None() {
		ModuleUI.Settings(EnumPage.Menu);
		ModuleInput.Settings(EnumInputMode.None);
		ModuleCamera.Mode(EnumCameraMode.None);
	}
	/// <summary> 标准模式 </summary>
	private static void EnumRunningMode_Standard() {
		ModuleUI.Settings(EnumPage.Battle);
		ModuleInput.Settings(EnumInputMode.Standard);
		ModuleCamera.Mode(EnumCameraMode.MoveAxis);
		ManagerMap.I.Initial();
		ManagerBattle.I.Initial();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 游戏管理
/// </summary>
public class SingleManager : ModuleSingle<SingleManager> {

	protected override void Awake() => NoReplace();

	private void Start() {
		ModuleUI.Settings(Page.Home);
		ModuleInput.Settings(InputMode.None);
		ModuleCamera.Settings(CameraMode.None);
	}
}

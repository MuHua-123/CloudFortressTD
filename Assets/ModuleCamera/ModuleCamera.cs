using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 相机模块
/// </summary>
public class ModuleCamera : ModuleSingle<ModuleCamera> {

	/// <summary> 当前相机 </summary>
	public static CameraControl Control;
	/// <summary> 相机模式事件 </summary>
	public static event Action<CameraMode> OnCameraMode;

	/// <summary> 设置相机模式 </summary>
	public static void Settings(CameraMode mode, bool isReset = true) {
		OnCameraMode?.Invoke(mode);
		if (isReset) { I.ResetCamera(); }
	}

	public List<CameraControl> controls;

	protected override void Awake() {
		NoReplace();
		controls.ForEach(obj => obj.Initial());
	}

	private void OnDestroy() => controls.ForEach(obj => obj.Release());

	/// <summary> 重置相机 </summary>
	public void ResetCamera() => controls.ForEach(obj => obj.ResetCamera());

}

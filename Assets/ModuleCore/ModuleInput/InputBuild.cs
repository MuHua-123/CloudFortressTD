using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 输入 - 构建
/// </summary>
public class InputBuild : MonoBehaviour {

	private TurretBasic preview;

	private CameraController CameraController => ModuleCamera.CurrentCamera;

	private void Update() {
		if (preview == null || CameraController == null) { return; }
		Vector3 worldPosition = CameraController.ScreenToWorldPosition(ModuleInput.mousePosition);
		if (!ManagerMap.TryWorldPosition(worldPosition, out Vector3 position)) { return; }
		preview.transform.position = Vector3.Lerp(preview.transform.position, position, Time.deltaTime * 20);
	}

	/// <summary> 启用预览 </summary>
	public void EnablePreview(TurretBasic turretBasic) {
		ModuleInput.TemporarilyDisable(true);
		ModuleVisual.I.GeneratorTurretBasic.CreateVisual(ref preview, turretBasic.transform);
	}

	#region 输入
	public void OnBuild(InputValue value) {
		ModuleInput.TemporarilyDisable(false);
	}
	public void OnCancel(InputValue value) {
		ModuleInput.TemporarilyDisable(false);
		ModuleVisual.I.GeneratorTurretBasic.ReleaseVisual(preview);
	}
	#endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 输入 - 构建
/// </summary>
public class InputBuild : MonoBehaviour {

	private HTurret preview;

	private CameraController CameraController => ModuleCamera.CurrentCamera;

	private void Update() {
		if (preview == null || CameraController == null) { return; }
		Vector3 position = GetMousePosition();
		preview.transform.position = Vector3.Lerp(preview.transform.position, position, Time.deltaTime * 20);
	}

	/// <summary> 启用预览 </summary>
	public void EnablePreview(HTurret hTurret) {
		ModuleInput.TemporarilyDisable(true);
		ModuleVisual.I.HTurret.UpdateVisual(ref preview, hTurret.transform);

		if (preview == null || CameraController == null) { return; }
		preview.transform.position = GetMousePosition();
	}

	#region 输入
	public void OnBuild(InputValue value) {
		if (preview == null) { return; }
		ModuleInput.TemporarilyDisable(false);
		CTurret.AddControl(preview).Initial();
		preview = null;
	}
	public void OnCancel(InputValue value) {
		if (preview == null) { return; }
		ModuleInput.TemporarilyDisable(false);
		ModuleVisual.I.HTurret.ReleaseVisual(preview);
	}
	#endregion

	/// <summary> 获取鼠标位置 </summary>
	private Vector3 GetMousePosition() {
		Vector3 worldPosition = CameraController.ScreenToWorldPosition(ModuleInput.mousePosition);
		if (!ManagerMap.TryWorldPosition(worldPosition, out Vector3 position)) { return worldPosition; }
		return position;
	}
}

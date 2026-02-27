using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 默认 - 相机
/// </summary>
public class CameraDefault : CameraControl {

	public Camera mainCamera;

	public override Camera Camera {
		get => mainCamera;
	}
	public override Vector3 Right {
		get => mainCamera.transform.right;
		set => mainCamera.transform.right = value;
	}
	public override Vector3 Forward {
		get => mainCamera.transform.forward;
		set => mainCamera.transform.forward = value;
	}
	public override Vector3 Position {
		get => transform.position;
		set => transform.position = value;
	}
	public override Vector3 EulerAngles {
		get => transform.eulerAngles;
		set => transform.eulerAngles = value;
	}
	public override float VisualField {
		get => throw new System.NotImplementedException();
		set => throw new System.NotImplementedException();
	}

	public override void ModuleCamera_OnCameraMode(CameraMode mode) {
		gameObject.SetActive(mode == CameraMode.None);
		if (mode == CameraMode.None) { ModuleCamera.Control = this; }
	}

	public override void ResetCamera() {
		// if (!Utilities.FindObject(out SettingsScene settings)) { return; }
		// transform.position = settings.InitialPosition.position;
		// transform.eulerAngles = settings.InitialPosition.eulerAngles;
	}
}

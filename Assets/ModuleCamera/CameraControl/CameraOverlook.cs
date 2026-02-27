using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 俯视相机
/// </summary>
public class CameraOverlook : CameraControl {

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
		get => Vector3.zero;
		set { }
	}
	public override float VisualField {
		get => mainCamera.orthographicSize;
		set => mainCamera.orthographicSize = value;
	}

	public override void ModuleCamera_OnCameraMode(CameraMode mode) {
		gameObject.SetActive(mode == CameraMode.Overlook);
		if (mode == CameraMode.Overlook) { ModuleCamera.Control = this; }
	}

	public override void ResetCamera() {
		// if (!Utilities.FindObject(out SettingsScene settings)) { return; }
		// transform.position = settings.InitialPosition.position;
		// transform.eulerAngles = settings.InitialPosition.eulerAngles;
	}
}

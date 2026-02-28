using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 观察相机
/// </summary>
public class CameraObserve : CameraControl {

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
		get => Mathf.Abs(mainCamera.transform.localPosition.z);
		set => mainCamera.transform.localPosition = new Vector3(0, 0, -value);
	}

	public override void ModuleCamera_OnCameraMode(CameraMode mode) {
		gameObject.SetActive(mode == CameraMode.Observe);
		if (mode == CameraMode.Observe) { ModuleCamera.Control = this; }
	}

	public override void ResetCamera() {
		// if (!Utilities.FindObject(out SettingsScene settings)) { return; }
		// transform.position = settings.InitialPosition.position;
		// transform.eulerAngles = settings.InitialPosition.eulerAngles;
	}

	public Texture2D CaptureCamera(int width = 2560, int height = 1440) {
		// 在主线程调用
		if (mainCamera == null) return null;

		// 创建临时 RenderTexture
		RenderTexture rt = RenderTexture.GetTemporary(width, height, 24, RenderTextureFormat.ARGB32);
		RenderTexture prevActive = RenderTexture.active;
		RenderTexture prevTarget = mainCamera.targetTexture;

		mainCamera.targetTexture = rt;
		mainCamera.Render();

		RenderTexture.active = rt;
		Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
		tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		tex.Apply();

		// 恢复并释放
		RenderTexture.active = prevActive;
		mainCamera.targetTexture = prevTarget;
		RenderTexture.ReleaseTemporary(rt);

		return tex;
	}
}

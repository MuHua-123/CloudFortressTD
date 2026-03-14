using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MuHua;
using System;

/// <summary>
/// 相机 - 输入器
/// </summary>
public class InputCamera : InputControl {

	// public bool isEnable;
	public float visualField = 20;

	private InputCameraMove cameraMove = new InputCameraMove();
	private InputCameraRotate cameraRotate = new InputCameraRotate();

	private CameraControl CameraControl => ModuleCamera.Control;

	protected override void Awake() {
		base.Awake();
		ModuleCamera.OnCameraMode += ModuleCamera_OnCameraMode;
	}
	protected override void OnDestroy() {
		base.OnDestroy();
		ModuleCamera.OnCameraMode -= ModuleCamera_OnCameraMode;
	}

	protected override void ModuleInput_OnInputMode(InputMode mode) {
		bool isEnable = mode == InputMode.Standard;

		enabled = isEnable;
		Input.enabled = isEnable;
	}
	private void ModuleCamera_OnCameraMode(CameraMode mode) {
		cameraRotate.Up();
	}

	private void Update() {
		if (CameraControl != null) {
			float original = CameraControl.VisualField;
			float v = Mathf.Lerp(original, visualField, Time.deltaTime * 10);
			CameraControl.VisualField = v;
		}

		cameraMove.Drag();
		cameraRotate.Drag();
	}

	#region 输入系统
	/// <summary> 移动 </summary>
	public void OnMove(InputValue inputValue) {
		if (ModuleInput.IsPointerOverUIObject) { return; }
		if (inputValue.isPressed) { cameraMove.Down(); }
		else { cameraMove.Up(); }
	}
	/// <summary> 旋转 </summary>
	public void OnRotate(InputValue inputValue) {
		// if (!isEnable) { return; }
		if (!inputValue.isPressed) { cameraRotate.Up(); return; }
		if (ModuleInput.IsPointerOverUIObject) { return; }
		if (inputValue.isPressed) { cameraRotate.Down(); }
	}
	/// <summary> 缩放视图 </summary>
	public void OnZoomView(InputValue inputValue) {
		if (ModuleInput.IsPointerOverUIObject) { return; }
		Vector2 scroll = inputValue.Get<Vector2>();
		visualField = CameraControl.VisualField - scroll.y * 40;
		visualField = Mathf.Clamp(visualField, 5, 250);
	}
	#endregion
}
/// <summary>
/// 相机移动
/// </summary>
public class InputCameraMove {

	public static bool isDown;
	public static bool isValid;
	public Vector3 postiton;
	public Vector2 mousePosition;

	private CameraControl CameraControl => ModuleCamera.Control;

	/// <summary> 按下 </summary>
	public void Down() {
		isDown = true;
		isValid = false;
		postiton = CameraControl.Position;
		mousePosition = ModuleInput.mousePosition;
	}
	/// <summary> 拖动 </summary>
	public void Drag() {
		if (!isDown) { return; }
		bool b1 = WorldPosition(mousePosition, out Vector3 v1);
		bool b2 = WorldPosition(ModuleInput.mousePosition, out Vector3 v2);
		if (!b1 || !b2) { return; }
		float distance = Vector3.Distance(v1, v2);
		if (distance > 0.1f) { isValid = true; }
		Vector3 offset = v1 - v2;
		CameraControl.Position = postiton + offset;
	}
	/// <summary> 抬起 </summary>
	public void Up() {
		isDown = false;
	}
	/// <summary> 重置 </summary>
	public void Reset(Vector3 postiton) {
		CameraControl.Position = postiton;
	}

	private bool WorldPosition(Vector2 screenPosition, out Vector3 position) {
		return RayManager.GroundPosition(screenPosition, out position);
	}
}
/// <summary>
/// 相机移动
/// </summary>
public class InputCameraRotate {

	public static bool isDown;
	public static bool isValid;
	public Vector2 original;
	public Vector2 eulerAngles;
	public Vector2 mousePosition;

	private CameraControl CameraControl => ModuleCamera.Control;

	/// <summary> 按下 </summary>
	public void Down() {
		isDown = true;
		original = eulerAngles = CameraControl.EulerAngles;
		mousePosition = ModuleInput.mousePosition;
	}
	/// <summary> 拖动 </summary>
	public void Drag() {
		if (!isDown) { return; }
		float distance = Vector3.Distance(ModuleInput.mousePosition, mousePosition);
		if (distance > 1f) { isValid = true; }

		Vector3 offset = ModuleInput.mousePosition - mousePosition;
		float x = offset.y / Screen.height * 180;
		float y = offset.x / Screen.width * 360;
		eulerAngles = original + new Vector2(-x, y);
		CameraControl.EulerAngles = eulerAngles;
	}
	/// <summary> 抬起 </summary>
	public void Up() {
		isDown = false;
	}
	/// <summary> 重置 </summary>
	public void Reset(Vector3 eulerAngles) {
		this.eulerAngles = eulerAngles;
		CameraControl.EulerAngles = eulerAngles;
	}
}
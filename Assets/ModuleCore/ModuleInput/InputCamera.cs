using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 相机 - 输入
/// </summary>
public class InputCamera : MonoBehaviour {

	public bool isMovement = false;
	public bool isRotating = false;
	public Vector2 delta;

	private bool isEnable;
	private Vector3 mousePosition1;
	private Vector3 mousePosition2;
	private Vector3 originalPosition;
	private Vector3 eulerAngles;
	private Vector3 originalEulerAngles;

	private CameraController CameraController => ModuleCamera.CurrentCamera;

	private void Awake() {
		ModuleInput.OnInputMode += ModuleInput_OnInputMode;
	}

	private void ModuleInput_OnInputMode(EnumInputMode mode) {
		isEnable = mode == EnumInputMode.Standard;
	}

	private void Update() {
		MovementCamera();
		RotatingCamera();
	}

	#region 输入
	public void OnEnableMovement(InputValue inputValue) {
		if (!isEnable) { return; }
		isMovement = inputValue.isPressed;
		mousePosition1 = ModuleInput.mousePosition;
		originalPosition = CameraController.Position;
	}
	public void OnEnableRotating(InputValue inputValue) {
		if (!isEnable) { return; }
		isRotating = inputValue.isPressed;
		mousePosition2 = ModuleInput.mousePosition;
		eulerAngles = originalEulerAngles = CameraController.EulerAngles;
	}
	#endregion

	private void MovementCamera() {
		if (!isEnable || !isMovement) { return; }
		Vector3 original = CameraController.ScreenToWorldPosition(mousePosition1);
		Vector3 current = CameraController.ScreenToWorldPosition(ModuleInput.mousePosition);
		Vector3 offset = current - original;
		CameraController.Position = originalPosition - offset;
	}
	private void RotatingCamera() {
		if (!isEnable || !isRotating) { return; }
		float differ = (ModuleInput.mousePosition.x - mousePosition2.x) / Screen.width;
		Vector3 current = originalEulerAngles + new Vector3(0, differ * 360, 0);
		eulerAngles = Vector3.Lerp(eulerAngles, current, Time.deltaTime * 10);
		CameraController.EulerAngles = eulerAngles;
	}
}

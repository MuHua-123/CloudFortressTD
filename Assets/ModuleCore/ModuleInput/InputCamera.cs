using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputCamera : OldModuleInput {

    /// <summary> 当前相机模块 </summary>
    public OldModuleCamera CurrentCamera => ModuleCore.CurrentCamera;

    private void Start() {
        eulerAngles = originalEulerAngles = CurrentCamera.EulerAngles;
    }

    #region 移动
    private void Update() {
        originalEulerAngles = Vector3.Lerp(originalEulerAngles, eulerAngles, Time.deltaTime * 20);
        CurrentCamera.EulerAngles = originalEulerAngles;
        if (!isMouseRight) { return; }
        Vector3 original = CurrentCamera.ScreenToWorldPosition(originalMousePosition);
        Vector3 current = CurrentCamera.ScreenToWorldPosition(mousePosition);
        Vector3 offset = current - original;
        CurrentCamera.Position = originalPosition - offset;
    }
    #endregion

    #region 输入
    private bool isMouseRight;
    private Vector3 eulerAngles;
    private Vector2 mousePosition;
    private Vector3 originalPosition;
    private Vector3 originalEulerAngles;
    private Vector3 originalMousePosition;
    public void OnMouseRight(InputValue value) {
        isMouseRight = value.isPressed;
        originalPosition = CurrentCamera.Position;
        originalMousePosition = mousePosition;
    }
    public void OnMouseScroll(InputValue value) {
        CurrentCamera.VisualField += value.Get<Vector2>().y;
    }
    public void OnMousePosition(InputValue value) {
        mousePosition = value.Get<Vector2>();
    }
    public void OnRotate(InputValue value) {
        float angle = value.Get<float>() * 45;
        eulerAngles += new Vector3(0, angle, 0);
    }
    #endregion
}

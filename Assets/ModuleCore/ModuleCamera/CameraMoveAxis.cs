using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

/// <summary>
/// 移轴相机
/// </summary>
public class CameraMoveAxis : OldModuleCamera {
    public Camera Camera;
    public Volume Volume;

    private LayerMask CameraPosition => LayerMaskTool.CameraPosition;
    public override Vector3 Position {
        get => transform.position;
        set => transform.position = value;
    }
    public override Vector3 EulerAngles {
        get => transform.eulerAngles;
        set => transform.eulerAngles = value;
    }
    public override float VisualField {
        get => GetVisualField();
        set => SetVisualField(value);
    }
    public override Camera ViewCamera => Camera;

    private float GetVisualField() {
        return Vector3.Distance(Camera.transform.localPosition, Vector3.zero);
    }
    private void SetVisualField(float value) {
        value = Mathf.Clamp(value, 10, 30);
        Vector3 direction = Camera.transform.localPosition - Vector3.zero;
        Camera.transform.localPosition = direction.normalized * value;
        if (!Volume.profile.TryGet(out DepthOfField depthOfField)) { return; }
        depthOfField.focusDistance.SetValue(new FloatParameter(value));
    }

    protected override void Awake() => ModuleCore.CurrentCamera = this;

    public override Vector3 ScreenToViewPosition(Vector3 screenPosition) {
        return Camera.ScreenToViewportPoint(screenPosition);
    }
    public override Vector3 ScreenToWorldPosition(Vector3 screenPosition) {
        Ray ray = Camera.ScreenPointToRay(screenPosition);
        Physics.Raycast(ray, out hitInfo, 200f, CameraPosition);
        Vector3 position = Vector3.zero;
        if (hitInfo.transform != null) { position = hitInfo.point; }
        return position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 震动
/// </summary>
public class DataShakeCamera {
    /// <summary> 震动量 </summary>
    public float shakeAmount;
    /// <summary> 震动持续时间 </summary>
    public float shakeDuration;
}
/// <summary>
/// 震动相机 独立模块
/// </summary>
public class ExecuteShakeCamera : ModuleFixed, ModuleExecute<DataShakeCamera> {
    public Transform cameraTransform;
    public float decreaseFactor = 1.0f;
    private DataShakeCamera shake = new DataShakeCamera();

    /// <summary> 震动量 </summary>
    public float ShakeAmount {
        get => shake.shakeAmount;
        set => shake.shakeAmount = value;
    }
    /// <summary> 震动持续时间 </summary>
    public float ShakeDuration {
        get => shake.shakeDuration;
        set => shake.shakeDuration = value;
    }

    /// <summary> 当前相机模块 </summary>
    public OldModuleCamera CurrentCamera => ModuleCore.CurrentCamera;

    public void Awake() {
        ModuleCore.ExecuteShakeCamera = this;
    }
    public void Update() {
        float deltaTime = Time.deltaTime * decreaseFactor;
        if (ShakeDuration > 0) {
            ShakeDuration -= deltaTime;
            cameraTransform.position = Random.insideUnitSphere * ShakeAmount;
        }
        if (ShakeAmount > 0) { ShakeAmount -= deltaTime; }
        else { cameraTransform.position = Vector3.zero; }
    }

    public void Execute(DataShakeCamera shake) => this.shake = shake;
}

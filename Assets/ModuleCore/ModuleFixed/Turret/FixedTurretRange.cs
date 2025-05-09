using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 炮塔范围显示
/// </summary>
public class FixedTurretRange : ModuleFixed {
    public Transform maxSphereRange;
    public Transform minSphereRange;
    private DataTurret turret;

    private Transform Follower => turret.visual.transform;
    /// <summary> 炮塔 DataTurret 数据处理器 </summary>
    public ModuleHandle<DataTurret> HandleTurret => ModuleCore.HandleTurret;

    private void Start() {
        HandleTurret.OnChange += HandleTurret_OnChange;
    }
    private void OnDestroy() {
        HandleTurret.OnChange -= HandleTurret_OnChange;
    }

    private void HandleTurret_OnChange(DataTurret turret) {
        this.turret = turret;
        maxSphereRange.gameObject.SetActive(turret != null);
        minSphereRange.gameObject.SetActive(turret != null);
        if (turret == null) { return; }
        SetSphereRange(maxSphereRange, turret.MaxAttackRange);
        SetSphereRange(minSphereRange, turret.MinAttackRange);
    }
    private void SetSphereRange(Transform sphereRange, float range) {
        float diameter = range * 2;
        sphereRange.localScale = new Vector3(diameter, diameter, diameter);
        Material material = sphereRange.GetComponent<MeshRenderer>().material;
        material.SetFloat("_Size", diameter);
        sphereRange.position = Follower.position + new Vector3(0, 0.1f, 0);
    }
}

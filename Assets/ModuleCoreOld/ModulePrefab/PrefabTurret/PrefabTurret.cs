using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTurret : ModulePrefab<DataTurret>, IBuilding {
    public Animator animator => GetComponent<Animator>();
    public TurretComponentLaunch launch => GetComponent<TurretComponentLaunch>();
    public TurretComponentDetection detection => GetComponent<TurretComponentDetection>();

    private void Awake() {
        ModuleCore.HandleGameState.OnChange += HandleGameState_OnChange;
    }
    private void OnDestroy() {
        ModuleCore.HandleGameState.OnChange -= HandleGameState_OnChange;
    }

    /// <summary> 设置动画速度 </summary>
    private void HandleGameState_OnChange(DataGameState obj) {
        float PlaySpeed = Mathf.Max(1f, obj.PlaySpeed);
        animator.SetFloat("PlaySpeed", PlaySpeed);
    }

    #region 建筑功能
    public void Preview() {
        //释放组件
        detection.enabled = false;
    }
    public void Build() {
        //初始化组件
        detection.enabled = true;
        launch.Initialize(Value);
        detection.Initialize(Value);
        //动画
        animator.SetTrigger("Install");
        HandleGameState_OnChange(ModuleCore.HandleGameState.Current);
    }
    public void Demolition() {
        //释放组件
        detection.enabled = false;
        //动画
        animator.SetTrigger("Remove");
    }
    #endregion

}

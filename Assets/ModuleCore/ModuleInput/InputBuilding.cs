using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 经典模式建造 输入
/// </summary>
public class InputBuilding : OldModuleInput {
    private GameObject prefabTurret;
    private ConstTurret presets;

    /// <summary> 格子地图  </summary>
    public DataGridMap GridMap => HandleGridMap.Current;
    /// <summary> 当前游戏状态 </summary>
    public DataGameState GameState => HandleGameState.Current;

    /// <summary> 当前相机模块 </summary>
    public OldModuleCamera CurrentCamera => ModuleCore.CurrentCamera;
    /// <summary> 格子地图 DataGridMap 数据处理器 </summary>
    public ModuleHandle<DataGridMap> HandleGridMap => ModuleCore.HandleGridMap;
    /// <summary> 游戏状态 DataGameState 数据处理器 </summary>
    public ModuleHandle<DataGameState> HandleGameState => ModuleCore.HandleGameState;
    /// <summary> 炮塔建造 ConstTurret 数据处理器 </summary>
    public ModuleHandle<ConstTurret> HandleTurretBuild => ModuleCore.HandleTurretBuild;
    /// <summary> 炮塔 资产 </summary>
    public ModuleAssets<DataTurret> AssetsTurret => ModuleCore.AssetsTurret;
    /// <summary> 怪物生产管理器 资产 </summary>
    public ModuleAssets<FixedMonsterSpawn> AssetsMonsterSpawn => ModuleCore.AssetsMonsterSpawn;

    protected override void Awake() {
        HandleTurretBuild.OnChange += HandleTurretBuild_OnChange;
    }
    private void OnDestroy() {
        HandleTurretBuild.OnChange -= HandleTurretBuild_OnChange;
    }
    private void Update() {
        Vector3 worldPosition = CurrentCamera.ScreenToWorldPosition(mousePosition);
        if (!GridMap.TryWorldPosition(worldPosition, out int x, out int y)) { return; }
        Vector3 position = GridMap.GetWorldPosition(x, y);
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * 20);
    }

    private void HandleTurretBuild_OnChange(ConstTurret presets) {
        Destroy(prefabTurret);
        this.presets = presets;
        if (presets == null) { return; }
        ConstTurretGrade grade = presets.grades[0];
        prefabTurret = Instantiate(grade.prefab, transform).gameObject;
        IBuilding building = prefabTurret.GetComponent<IBuilding>();
        building.Preview();
    }

    #region 输入
    private Vector2 mousePosition;
    public void OnBuild(InputValue value) {
        //预制数据是否有效
        if (presets == null) { return; }
        //是否启用预览
        if (prefabTurret == null) { return; }
        //UI指针判断
        if (PointerTool.IsPointerOverGameObject) { return; }
        //金币是否够建造
        if (GameState.GoldCoin < presets.BuildValue()) { return; }
        //地图范围判断
        if (!GridMap.TryGetMapUnit(transform.position, out DataGridMapUnit mapUnit)) { return; }
        //是否可以建造
        if (!mapUnit.isBuild) { return; }
        //建造完成后路径是否正常
        bool isPass = true;
        mapUnit.building = new TestBuilding();
        AssetsMonsterSpawn.ForEach(obj => { if (!obj.Pass()) { isPass = false; } });
        mapUnit.building = null;
        if (!isPass) { Destroy(prefabTurret); return; }
        //扣除金币
        int buildValue = presets.BuildValue();
        GameState.GoldCoin -= buildValue;
        presets.BuildCount(1);
        //完成建造
        DataTurret turret = presets.To(mapUnit);
        turret.buildValue = buildValue;
        AssetsTurret.Add(turret);
        //移除建筑幽灵预览
        Destroy(prefabTurret);
    }
    public void OnCancelBuild(InputValue value) {
        Destroy(prefabTurret);
    }
    public void OnPosition(InputValue value) {
        mousePosition = value.Get<Vector2>();
    }
    #endregion

}
/// <summary>
/// 建筑物接口
/// </summary>
public interface IBuilding {
    /// <summary> 预览 </summary>
    public void Preview();
    /// <summary> 建造 </summary>
    public void Build();
    /// <summary> 拆除 </summary>
    public void Demolition();
}
/// <summary>
/// 测试建筑
/// </summary>
public class TestBuilding : IBuilding {
    public void Preview() { throw new System.NotImplementedException(); }
    public void Build() { throw new System.NotImplementedException(); }
    public void Demolition() { throw new System.NotImplementedException(); }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualTurret : ModuleFixed, ModuleVisual<DataTurret> {
    /// <summary> 格子地图  </summary>
    public DataGridMap GridMap => HandleGridMap.Current;

    /// <summary> 格子地图 DataGridMap 数据处理器 </summary>
    public ModuleHandle<DataGridMap> HandleGridMap => ModuleCore.HandleGridMap;
    /// <summary> 连接墙 执行模块 </summary>
    public ModuleExecute<DataGridMapUnit> ExecuteConnectWall => ModuleCore.ExecuteConnectWall;

    public void Awake() => ModuleCore.VisualTurret = this;

    public void UpdateVisual(DataTurret turret) {
        turret.UpdateProperty();
        bool isInitBuild = turret.visual == null;
        ModuleVisualTool.Create(ref turret.visual, turret.Prefab, transform);
        turret.visual.UpdateVisual(turret);
        
        if (!isInitBuild) { return; }
        //设置位置
        turret.visual.transform.position = GridMap.GetWorldPosition(turret.X, turret.Y);
        //建筑初始化
        IBuilding building = turret.visual.GetComponent<IBuilding>();
        building.Build();
        //写入地图
        turret.mapUnit.building = building;
        HandleGridMap.Change();
        //创建墙
        ExecuteConnectWall.Execute(turret.mapUnit);
    }
    public void ReleaseVisual(DataTurret turret) {
        if (turret.visual == null) { return; }
        //建筑释放
        IBuilding building = turret.visual.GetComponent<IBuilding>();
        building.Demolition();
        //清空地图
        turret.mapUnit.building = null;
        HandleGridMap.Change();
        //删除墙
        ExecuteConnectWall.Execute(turret.mapUnit);
        //延迟删除可视化内容
        Destroy(turret.visual.gameObject, 0.4f);
    }
}

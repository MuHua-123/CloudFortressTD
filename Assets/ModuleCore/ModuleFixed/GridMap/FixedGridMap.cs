using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedGridMap : ModuleFixed {
    public Vector2Int mapSize;
    public Transform mapSpace;
    public GameObject mapPrefab;
    public List<Transform> mapUnit;

    public Vector3 OriginPosition => new Vector3(mapSize.x, 0, mapSize.y) * -0.5f;

    /// <summary> 格子地图 DataGridMap 数据处理器 </summary>
    public ModuleHandle<DataGridMap> HandleGridMap => ModuleCore.HandleGridMap;

    private void Awake() {
        DataGridMap gridMap = Initialize();
        HandleGridMap.Change(gridMap);
    }

    /// <summary> 初始化地图 </summary>
    private DataGridMap Initialize() {
        DataGridMap gridMap = new DataGridMap();
        gridMap.wide = mapSize.x;
        gridMap.high = mapSize.y;
        gridMap.originPosition = OriginPosition;
        gridMap.unitArray = new DataGridMapUnit[mapSize.x, mapSize.y];
        gridMap.Loop(Initialize);
        mapUnit.ForEach(obj => Initialize(gridMap, obj));
        return gridMap;
    }
    private void Initialize(DataGridMap gridMap, int x, int y) {
        DataGridMapUnit mapUnit = new DataGridMapUnit();
        mapUnit.x = x;
        mapUnit.y = y;
        gridMap.unitArray[x, y] = mapUnit;
    }
    private void Initialize(DataGridMap gridMap, Transform obj) {
        if (!obj.TryGetComponent(out FixedGridMapUnit fgmu)) { return; }
        if (!gridMap.TryGetMapUnit(obj.position, out DataGridMapUnit mapUnit)) { return; }
        mapUnit.fixedGridMapUnit = fgmu;
    }
}

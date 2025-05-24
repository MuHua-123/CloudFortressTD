using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 连接墙 独立模块
/// </summary>
public class ExecuteConnectWall : ModuleFixed, ModuleExecute<DataGridMapUnit> {
    public Transform wallPrefab1;
    public Transform wallPrefab2;

    /// <summary> 格子地图  </summary>
    public DataGridMap GridMap => HandleGridMap.Current;

    /// <summary> 格子地图 DataGridMap 数据处理器 </summary>
    public ModuleHandle<DataGridMap> HandleGridMap => ModuleCore.HandleGridMap;

    public void Awake() => ModuleCore.ExecuteConnectWall = this;

    public void Execute(DataGridMapUnit mapUnit) {
        if (mapUnit.isBuild) { DeleteWall(mapUnit); }
        else { CreateWall(mapUnit); }
    }

    #region 创建
    private void CreateWall(DataGridMapUnit mapUnit) {
        int x = mapUnit.x; int y = mapUnit.y;
        bool above = CreateWall(mapUnit, x, y + 1, 090, wallPrefab1, ConnectWallType.above);
        bool below = CreateWall(mapUnit, x, y - 1, 270, wallPrefab1, ConnectWallType.below);
        bool right = CreateWall(mapUnit, x + 1, y, 180, wallPrefab1, ConnectWallType.right);
        bool lefts = CreateWall(mapUnit, x - 1, y, 360, wallPrefab1, ConnectWallType.lefts);

        if (!lefts && !above) { CreateWall(mapUnit, x - 1, y + 1, 045, wallPrefab2, ConnectWallType.leftsAbove); }
        if (!lefts && !below) { CreateWall(mapUnit, x - 1, y - 1, 315, wallPrefab2, ConnectWallType.leftsBelow); }
        if (!right && !above) { CreateWall(mapUnit, x + 1, y + 1, 135, wallPrefab2, ConnectWallType.rightAbove); }
        if (!right && !below) { CreateWall(mapUnit, x + 1, y - 1, 225, wallPrefab2, ConnectWallType.rightBelow); }

        if (lefts && above) { DeleteWall(x - 1, y, x, y + 1, ConnectWallType.rightAbove); }
        if (lefts && below) { DeleteWall(x - 1, y, x, y - 1, ConnectWallType.rightBelow); }
        if (right && above) { DeleteWall(x + 1, y, x, y + 1, ConnectWallType.leftsAbove); }
        if (right && below) { DeleteWall(x + 1, y, x, y - 1, ConnectWallType.leftsBelow); }
    }
    private bool CreateWall(DataGridMapUnit mapUnit, int x, int y, float rotate, Transform prefab, ConnectWallType type) {
        if (!GridMap.TryGetMapUnit(x, y, out DataGridMapUnit unit)) { return false; }
        if (unit.isBuild) { return false; }
        Transform wall = Instantiate(prefab, transform);
        wall.position = GridMap.GetWorldPosition(mapUnit.x, mapUnit.y);
        wall.eulerAngles = new Vector3(0, rotate, 0);

        DataConnectWall connectWall1 = new DataConnectWall();
        connectWall1.type = type;
        connectWall1.wall = wall;
        mapUnit.connectWalls.Add(connectWall1);

        DataConnectWall connectWall2 = new DataConnectWall();
        connectWall2.type = Reverse(type);
        connectWall2.wall = wall;
        unit.connectWalls.Add(connectWall2);
        return true;
    }
    #endregion

    #region 删除
    private void DeleteWall(DataGridMapUnit mapUnit) {
        int x = mapUnit.x; int y = mapUnit.y;
        DeleteWall(x, y, x, y + 1, ConnectWallType.above);
        DeleteWall(x, y, x, y - 1, ConnectWallType.below);
        DeleteWall(x, y, x - 1, y, ConnectWallType.lefts);
        DeleteWall(x, y, x + 1, y, ConnectWallType.right);

        DeleteWall(x, y, x + 1, y + 1, ConnectWallType.rightAbove);
        DeleteWall(x, y, x + 1, y - 1, ConnectWallType.rightBelow);
        DeleteWall(x, y, x - 1, y + 1, ConnectWallType.leftsAbove);
        DeleteWall(x, y, x - 1, y - 1, ConnectWallType.leftsBelow);
    }
    private void DeleteWall(int x1, int y1, int x2, int y2, ConnectWallType type) {
        DataGridMapUnit unit1 = GridMap.GetMapUnit(x1, y1);
        for (int i = 0; i < unit1.connectWalls.Count; i++) {
            DataConnectWall connectWall = unit1.connectWalls[i];
            if (connectWall.type != type) { continue; }
            if (connectWall.wall != null) { Destroy(connectWall.wall.gameObject); }
            unit1.connectWalls.Remove(connectWall);
        }
        DataGridMapUnit unit2 = GridMap.GetMapUnit(x2, y2);
        type = Reverse(type);
        for (int i = 0; i < unit2.connectWalls.Count; i++) {
            DataConnectWall connectWall = unit2.connectWalls[i];
            if (connectWall.type != type) { continue; }
            if (connectWall.wall != null) { Destroy(connectWall.wall.gameObject); }
            unit2.connectWalls.Remove(connectWall);
        }
    }
    #endregion

    private ConnectWallType Reverse(ConnectWallType type) {
        if (type == ConnectWallType.above) { return ConnectWallType.below; }
        if (type == ConnectWallType.below) { return ConnectWallType.above; }
        if (type == ConnectWallType.lefts) { return ConnectWallType.right; }
        if (type == ConnectWallType.right) { return ConnectWallType.lefts; }

        if (type == ConnectWallType.leftsAbove) { return ConnectWallType.rightBelow; }
        if (type == ConnectWallType.leftsBelow) { return ConnectWallType.rightAbove; }
        if (type == ConnectWallType.rightAbove) { return ConnectWallType.leftsBelow; }
        if (type == ConnectWallType.rightBelow) { return ConnectWallType.leftsAbove; }
        return type;
    }

}

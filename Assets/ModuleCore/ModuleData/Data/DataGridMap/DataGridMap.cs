using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 格子地图数据
/// </summary>
public class DataGridMap {
    /// <summary> 地图宽 </summary>
    public int wide;
    /// <summary> 地图高 </summary>
    public int high;
    /// <summary> 原点 </summary>
    public Vector3 originPosition;
    /// <summary> 地图单元数据 </summary>
    public DataGridMapUnit[,] unitArray;

    /// <summary> 地图单元数据 </summary>
    public DataGridMapUnit this[int x, int y] {
        get => unitArray[x, y];
        set => unitArray[x, y] = value;
    }
}
/// <summary>
/// 格子地图工具
/// </summary>
public static class DataGridMapTool {
    /// <summary> 遍历地图 </summary>
    public static void Loop(this DataGridMap gridMap, Action<DataGridMap, int, int> action) {
        for (int y = 0; y < gridMap.high; y++) {
            for (int x = 0; x < gridMap.wide; x++) { action?.Invoke(gridMap, x, y); }
        }
    }
    /*-------------------------------------------------坐标转换--------------------------------------------------------------*/
    public static Vector3 GetWorldPosition(this DataGridMap gridMap, Vector3 worldPosition) {
        gridMap.GetXY(worldPosition, out int x, out int y);
        return gridMap.GetWorldPosition(x, y);
    }
    public static Vector3 GetWorldPosition(this DataGridMap gridMap, int x, int y) {
        Vector3 offset = new Vector3(0.5f, 0, 0.5f);
        return new Vector3(x, 0, y) + gridMap.originPosition + offset;
    }
    public static void GetXY(this DataGridMap gridMap, Vector3 worldPosition, out int x, out int y) {
        float xOffset = gridMap.wide % 2 == 1 ? 0.5f : 0;
        float yOffset = gridMap.high % 2 == 1 ? 0.5f : 0;
        x = Mathf.FloorToInt((worldPosition - gridMap.originPosition).x);
        y = Mathf.FloorToInt((worldPosition - gridMap.originPosition).z);
    }
    /*-------------------------------------------------校验范围--------------------------------------------------------------*/
    public static bool TryWorldPosition(this DataGridMap gridMap, Vector3 worldPosition, out int x, out int y) {
        gridMap.GetXY(worldPosition, out x, out y);
        return gridMap.TryGetXY(x, y);
    }
    public static bool TryGetXY(this DataGridMap gridMap, int x, int y) {
        return x >= 0 && x < gridMap.wide && y >= 0 && y < gridMap.high;
    }
    /*-------------------------------------------------单元操作--------------------------------------------------------------*/
    public static DataGridMapUnit GetMapUnit(this DataGridMap gridMap, Vector3 worldPosition) {
        gridMap.GetXY(worldPosition, out int x, out int y);
        return gridMap.GetMapUnit(x, y);
    }
    public static DataGridMapUnit GetMapUnit(this DataGridMap gridMap, int x, int y) {
        x = Mathf.Clamp(x, 0, gridMap.wide - 1);
        y = Mathf.Clamp(y, 0, gridMap.high - 1);
        return gridMap.unitArray[x, y];
    }
    public static void SetMapUnit(this DataGridMap gridMap, Vector3 worldPosition, DataGridMapUnit mapUnit) {
        gridMap.GetXY(worldPosition, out int x, out int y);
        gridMap.SetMapUnit(x, y, mapUnit);
    }
    public static void SetMapUnit(this DataGridMap gridMap, int x, int y, DataGridMapUnit mapUnit) {
        x = Mathf.Clamp(x, 0, gridMap.wide - 1);
        y = Mathf.Clamp(y, 0, gridMap.high - 1);
        gridMap.unitArray[x, y] = mapUnit;
    }
    /*-------------------------------------------------校验单元--------------------------------------------------------------*/
    public static bool TryGetMapUnit(this DataGridMap gridMap, Vector3 worldPosition, out DataGridMapUnit unit) {
        gridMap.GetXY(worldPosition, out int x, out int y);
        return gridMap.TryGetMapUnit(x, y, out unit);
    }
    public static bool TryGetMapUnit(this DataGridMap gridMap, int x, int y, out DataGridMapUnit unit) {
        unit = gridMap.GetMapUnit(x, y);
        return gridMap.TryGetXY(x, y);
    }
    public static bool TrySetMapUnit(this DataGridMap gridMap, Vector3 worldPosition, DataGridMapUnit mapUnit) {
        gridMap.GetXY(worldPosition, out int x, out int y);
        return gridMap.TrySetMapUnit(x, y, mapUnit);
    }
    public static bool TrySetMapUnit(this DataGridMap gridMap, int x, int y, DataGridMapUnit mapUnit) {
        if (gridMap.TryGetXY(x, y)) { gridMap.unitArray[x, y] = mapUnit; return true; }
        else { return false; }
    }
    /*-------------------------------------------------查询范围--------------------------------------------------------------*/
    /// <summary> 获取相邻的节点 </summary>
    public static List<DataGridMapUnit> FindNeighbour(this DataGridMap gridMap, int x, int y) {
        List<DataGridMapUnit> neighbourList = new List<DataGridMapUnit>();
        if (gridMap.TryGetMapUnit(x, y + 1, out DataGridMapUnit unit1)) { neighbourList.Add(unit1); }
        if (gridMap.TryGetMapUnit(x, y - 1, out DataGridMapUnit unit2)) { neighbourList.Add(unit2); }
        if (gridMap.TryGetMapUnit(x + 1, y, out DataGridMapUnit unit3)) { neighbourList.Add(unit3); }
        if (gridMap.TryGetMapUnit(x - 1, y, out DataGridMapUnit unit4)) { neighbourList.Add(unit4); }
        if (gridMap.TryGetMapUnit(x + 1, y + 1, out DataGridMapUnit unit5)) { neighbourList.Add(unit5); }
        if (gridMap.TryGetMapUnit(x + 1, y - 1, out DataGridMapUnit unit6)) { neighbourList.Add(unit6); }
        if (gridMap.TryGetMapUnit(x - 1, y + 1, out DataGridMapUnit unit7)) { neighbourList.Add(unit7); }
        if (gridMap.TryGetMapUnit(x - 1, y - 1, out DataGridMapUnit unit8)) { neighbourList.Add(unit8); }
        return neighbourList;
    }
    /// <summary> 获取相连的节点 </summary>
    public static List<DataGridMapUnit> FindConnected(this DataGridMap gridMap, int x, int y) {
        List<DataGridMapUnit> neighbourList = new List<DataGridMapUnit>();
        if (gridMap.TryGetMapUnit(x, y + 1, out DataGridMapUnit unit1)) { neighbourList.Add(unit1); }
        if (gridMap.TryGetMapUnit(x, y - 1, out DataGridMapUnit unit2)) { neighbourList.Add(unit2); }
        if (gridMap.TryGetMapUnit(x + 1, y, out DataGridMapUnit unit3)) { neighbourList.Add(unit3); }
        if (gridMap.TryGetMapUnit(x - 1, y, out DataGridMapUnit unit4)) { neighbourList.Add(unit4); }
        return neighbourList;
    }
}
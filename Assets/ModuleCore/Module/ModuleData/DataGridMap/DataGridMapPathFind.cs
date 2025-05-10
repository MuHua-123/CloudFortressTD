using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 格子地图路径查询数据
/// </summary>
public class DataGridMapPathFind {
    /// <summary> 是否有效 </summary>
    public bool isValid = false;
    /// <summary> 拐角是否可以通行 </summary>
    public bool isCornerWalkable = false;
    /// <summary> 起点(世界坐标) </summary>
    public Vector3 sPosition;
    /// <summary> 终点(世界坐标) </summary>
    public Vector3 ePosition;
    /// <summary> 地图 </summary>
    public DataGridMap gridMap;

    /// <summary> 起点 </summary>
    public DataGridMapUnit sMapUnit;
    /// <summary> 终点 </summary>
    public DataGridMapUnit eMapUnit;
    /// <summary> 匹配的路径 </summary>
    public List<Vector3> vectorPath;

    /// <summary> 格子地图路径查询数据 </summary>
    public DataGridMapPathFind(DataGridMap gridMap, Vector3 sPosition, Vector3 ePosition) {
        this.gridMap = gridMap;
        this.sPosition = sPosition;
        this.ePosition = ePosition;
    }
}
/// <summary>
/// 格子地图路径查询工具
/// </summary>
public static class DataGridMapPathFindTool {
    /// <summary> 是否有效 </summary>
    public static bool TryValid(this DataGridMapPathFind pathFind) {
        bool isValidS = pathFind.gridMap.TryGetMapUnit(pathFind.sPosition, out pathFind.sMapUnit);
        bool isValidE = pathFind.gridMap.TryGetMapUnit(pathFind.ePosition, out pathFind.eMapUnit);
        return isValidS && isValidE && pathFind.eMapUnit.IsWalkable;
    }
}

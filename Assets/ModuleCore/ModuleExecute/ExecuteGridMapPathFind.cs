using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 网格地图路径查找 执行模块
/// </summary>
public class ExecuteGridMapPathFind : ModuleExecute<DataGridMapPathFind> {
    public const int MOVE_STRAIGHT_COST = 10;
    public const int MOVE_DIAGONAL_COST = 14;

    public void Execute(DataGridMapPathFind pathFind) {
        if (!pathFind.TryValid()) { return; }
        DataGridMap gridMap = pathFind.gridMap;
        List<DataGridMapUnit> path = FindPath(pathFind);
        if (path == null) { return; }
        pathFind.vectorPath = new List<Vector3>();
        foreach (DataGridMapUnit pathNode in path) {
            Vector3 position = gridMap.GetWorldPosition(pathNode.x, pathNode.y);
            pathFind.vectorPath.Add(position);
        }
        pathFind.isValid = pathFind.vectorPath.Count > 0;
    }
    /// <summary> 查询路径 </summary>
    public List<DataGridMapUnit> FindPath(DataGridMapPathFind pathFind) {
        DataGridMap gridMap = pathFind.gridMap;
        DataGridMapUnit sMapUnit = pathFind.sMapUnit;
        DataGridMapUnit eMapUnit = pathFind.eMapUnit;
        List<DataGridMapUnit> openList = new List<DataGridMapUnit> { sMapUnit };
        List<DataGridMapUnit> closeList = new List<DataGridMapUnit>();
        gridMap.Loop((map, x, y) => { map[x, y].InitializationCost(); });

        sMapUnit.GCost = 0;
        sMapUnit.HCost = CalculateDistanceCost(sMapUnit, eMapUnit);
        sMapUnit.CalculateFCost();

        while (openList.Count > 0) {
            DataGridMapUnit currentNode = GetLowestFCostNode(openList);
            //以达到最终目的地
            if (currentNode == eMapUnit) { return CalculatePath(eMapUnit); }
            openList.Remove(currentNode);
            closeList.Add(currentNode);
            CalculateNeighbour(gridMap, openList, closeList, currentNode, eMapUnit, pathFind.isCornerWalkable);
        }
        return null;
    }
    /// <summary> 计算距离h成本 </summary>
    public int CalculateDistanceCost(DataGridMapUnit a, DataGridMapUnit b) {
        int xDistance = Mathf.Abs(a.x - b.x);
        int yDistance = Mathf.Abs(a.y - b.y);
        int mDistance = Mathf.Min(xDistance, yDistance);
        int remaining = Mathf.Abs(xDistance - yDistance);
        return MOVE_DIAGONAL_COST * mDistance + MOVE_STRAIGHT_COST * remaining;
    }
    /// <summary> 获得最小f成本 </summary>
    public DataGridMapUnit GetLowestFCostNode(List<DataGridMapUnit> openList) {
        DataGridMapUnit lowestFCostNode = openList[0];
        for (int i = 0; i < openList.Count; i++) {
            if (openList[i].FCost >= lowestFCostNode.FCost) { continue; }
            lowestFCostNode = openList[i];
        }
        return lowestFCostNode;
    }
    /// <summary> 计算临近节点 </summary>
    public void CalculateNeighbour(DataGridMap gridMap, List<DataGridMapUnit> openList, List<DataGridMapUnit> closeList,
        DataGridMapUnit currentNode, DataGridMapUnit endNode, bool isCornerWalkable) {
        List<DataGridMapUnit> neighbourList = gridMap.FindConnected(currentNode.x, currentNode.y);
        foreach (DataGridMapUnit neighbourNode in neighbourList) {
            //如果临近节点在关闭列表则跳过
            if (closeList.Contains(neighbourNode)) { continue; }
            //如果节点不可通行则添加到关闭列表
            if (!neighbourNode.IsWalkable && neighbourNode != endNode) {
                closeList.Add(neighbourNode);
                continue;
            }
            //计算阻挡
            if (!isCornerWalkable && CornerWalkable(gridMap, currentNode, neighbourNode)) { continue; }

            //计算成本
            int tentativeGCost = currentNode.GCost + CalculateDistanceCost(currentNode, neighbourNode);
            if (tentativeGCost >= neighbourNode.GCost) { continue; }
            neighbourNode.CameFromNode = currentNode;
            neighbourNode.GCost = tentativeGCost;
            neighbourNode.HCost = CalculateDistanceCost(neighbourNode, endNode);
            neighbourNode.CalculateFCost();
            if (!openList.Contains(neighbourNode)) { openList.Add(neighbourNode); }
        }
    }
    /// <summary> 计算阻挡 </summary>
    public bool CornerWalkable(DataGridMap gridMap, DataGridMapUnit currentNode, DataGridMapUnit neighbourNode) {
        if (CalculateDistanceCost(currentNode, neighbourNode) != MOVE_DIAGONAL_COST) { return false; }
        int x = neighbourNode.x - currentNode.x;
        int y = neighbourNode.y - currentNode.y;
        DataGridMapUnit a = gridMap.unitArray[currentNode.x + x, currentNode.y];
        DataGridMapUnit b = gridMap.unitArray[currentNode.x, currentNode.y + y];
        return !a.IsWalkable || !b.IsWalkable;
    }
    /// <summary> 返回最终路径 </summary>
    public List<DataGridMapUnit> CalculatePath(DataGridMapUnit endNode) {
        List<DataGridMapUnit> FinalPath = new List<DataGridMapUnit>();
        DataGridMapUnit currentNode = endNode;
        while (currentNode.CameFromNode != null) {
            FinalPath.Add(currentNode);
            currentNode = currentNode.CameFromNode;
        }
        FinalPath.Add(currentNode);
        FinalPath.Reverse();
        return FinalPath;
    }
}

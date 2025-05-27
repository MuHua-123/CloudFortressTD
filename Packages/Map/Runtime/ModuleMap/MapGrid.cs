using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 格子地图
	/// </summary>
	public class MapGrid : ModuleMap {

		public const int MOVE_STRAIGHT_COST = 10;
		public const int MOVE_DIAGONAL_COST = 14;

		/// <summary> 地图宽 </summary>
		public readonly int wide;
		/// <summary> 地图高 </summary>
		public readonly int high;
		/// <summary> 原点 </summary>
		public readonly Vector3 originPosition;
		/// <summary> 地图单元数据 </summary>
		public DataMapUnit[,] unitArray;

		public MapGrid(int wide, int high, Vector3 originPosition) {
			this.wide = wide;
			this.high = high;
			this.originPosition = originPosition;

			unitArray = new DataMapUnit[wide, high];
			Loop((x, y) => unitArray[x, y] = new DataMapUnit(x, y));
		}
		/*-------------------------------------------------遍历地图--------------------------------------------------------------*/
		public void Loop(Action<int, int> action) {
			for (int y = 0; y < high; y++) {
				for (int x = 0; x < wide; x++) { action?.Invoke(x, y); }
			}
		}
		/*-------------------------------------------------校验范围--------------------------------------------------------------*/
		public bool TryWorldPosition(Vector3 worldPosition, out int x, out int y) {
			GetXY(worldPosition, out x, out y);
			return TryGetXY(x, y);
		}
		public bool TryGetXY(int x, int y) {
			return x >= 0 && x < wide && y >= 0 && y < high;
		}
		/*-------------------------------------------------坐标转换--------------------------------------------------------------*/
		public override bool TryWorldPosition(Vector3 worldPosition, out Vector3 position) {
			GetXY(worldPosition, out int x, out int y);
			position = GetWorldPosition(x, y);
			return TryGetXY(x, y);
		}
		public Vector3 GetWorldPosition(Vector3 worldPosition) {
			GetXY(worldPosition, out int x, out int y);
			return GetWorldPosition(x, y);
		}
		public Vector3 GetWorldPosition(int x, int y) {
			Vector3 offset = new Vector3(0.5f, 0, 0.5f);
			return new Vector3(x, 0, y) + originPosition + offset;
		}
		public void GetXY(Vector3 worldPosition, out int x, out int y) {
			x = Mathf.FloorToInt((worldPosition - originPosition).x);
			y = Mathf.FloorToInt((worldPosition - originPosition).z);
		}
		/*-------------------------------------------------单元操作--------------------------------------------------------------*/
		public DataMapUnit GetMapUnit(Vector3 worldPosition) {
			GetXY(worldPosition, out int x, out int y);
			return GetMapUnit(x, y);
		}
		public DataMapUnit GetMapUnit(int x, int y) {
			x = Mathf.Clamp(x, 0, wide - 1);
			y = Mathf.Clamp(y, 0, high - 1);
			return unitArray[x, y];
		}
		public void SetMapUnit(Vector3 worldPosition, DataMapUnit mapUnit) {
			GetXY(worldPosition, out int x, out int y);
			SetMapUnit(x, y, mapUnit);
		}
		public void SetMapUnit(int x, int y, DataMapUnit mapUnit) {
			x = Mathf.Clamp(x, 0, wide - 1);
			y = Mathf.Clamp(y, 0, high - 1);
			unitArray[x, y] = mapUnit;
		}
		/*-------------------------------------------------校验单元--------------------------------------------------------------*/
		public override bool TryGetMapUnit(Vector3 worldPosition, out DataMapUnit unit) {
			GetXY(worldPosition, out int x, out int y);
			return TryGetMapUnit(x, y, out unit);
		}
		public bool TryGetMapUnit(int x, int y, out DataMapUnit unit) {
			unit = GetMapUnit(x, y);
			return TryGetXY(x, y);
		}
		public bool TrySetMapUnit(Vector3 worldPosition, DataMapUnit mapUnit) {
			GetXY(worldPosition, out int x, out int y);
			return TrySetMapUnit(x, y, mapUnit);
		}
		public bool TrySetMapUnit(int x, int y, DataMapUnit mapUnit) {
			if (TryGetXY(x, y)) { unitArray[x, y] = mapUnit; return true; }
			else { return false; }
		}
		/*-------------------------------------------------查询范围--------------------------------------------------------------*/
		/// <summary> 获取相邻的节点 </summary>
		public List<DataMapUnit> FindNeighbour(int x, int y) {
			List<DataMapUnit> neighbourList = new List<DataMapUnit>();
			neighbourList.AddRange(FindConnected(x, y));
			if (TryGetMapUnit(x + 1, y + 1, out DataMapUnit unit5)) { neighbourList.Add(unit5); }
			if (TryGetMapUnit(x + 1, y - 1, out DataMapUnit unit6)) { neighbourList.Add(unit6); }
			if (TryGetMapUnit(x - 1, y + 1, out DataMapUnit unit7)) { neighbourList.Add(unit7); }
			if (TryGetMapUnit(x - 1, y - 1, out DataMapUnit unit8)) { neighbourList.Add(unit8); }
			return neighbourList;
		}
		/// <summary> 获取相连的节点 </summary>
		public List<DataMapUnit> FindConnected(int x, int y) {
			List<DataMapUnit> neighbourList = new List<DataMapUnit>();
			if (TryGetMapUnit(x, y + 1, out DataMapUnit unit1)) { neighbourList.Add(unit1); }
			if (TryGetMapUnit(x, y - 1, out DataMapUnit unit2)) { neighbourList.Add(unit2); }
			if (TryGetMapUnit(x + 1, y, out DataMapUnit unit3)) { neighbourList.Add(unit3); }
			if (TryGetMapUnit(x - 1, y, out DataMapUnit unit4)) { neighbourList.Add(unit4); }
			return neighbourList;
		}
		/*-------------------------------------------------查询路径--------------------------------------------------------------*/
		public override bool FindPath(Vector3 sp, Vector3 ep, bool isCornerWalkable, out List<Vector3> vectorPath) {
			vectorPath = new List<Vector3>();
			// 查询起点和终点
			bool isValidS = TryGetMapUnit(sp, out DataMapUnit sMapUnit);
			bool isValidE = TryGetMapUnit(ep, out DataMapUnit eMapUnit);
			if (!isValidS || !isValidE && eMapUnit.IsWalkable) { return false; }
			// 查询路径
			vectorPath = FindPath(sMapUnit, eMapUnit, isCornerWalkable);
			return vectorPath != null && vectorPath.Count > 0;
		}
		/// <summary> 查询路径 </summary>
		public List<Vector3> FindPath(DataMapUnit sMapUnit, DataMapUnit eMapUnit, bool isCornerWalkable) {
			List<DataMapUnit> openList = new List<DataMapUnit> { sMapUnit };
			List<DataMapUnit> closeList = new List<DataMapUnit>();
			Loop((x, y) => { unitArray[x, y].InitializationCost(); });

			sMapUnit.GCost = 0;
			sMapUnit.HCost = CalculateDistanceCost(sMapUnit, eMapUnit);
			sMapUnit.CalculateFCost();

			while (openList.Count > 0) {
				DataMapUnit currentNode = GetLowestFCostNode(openList);
				//以达到最终目的地
				if (currentNode == eMapUnit) { return CalculatePath(eMapUnit); }
				openList.Remove(currentNode);
				closeList.Add(currentNode);
				CalculateNeighbour(openList, closeList, currentNode, eMapUnit, isCornerWalkable);
			}
			return null;
		}
		/// <summary> 计算距离h成本 </summary>
		public int CalculateDistanceCost(DataMapUnit a, DataMapUnit b) {
			int xDistance = Mathf.Abs(a.x - b.x);
			int yDistance = Mathf.Abs(a.y - b.y);
			int mDistance = Mathf.Min(xDistance, yDistance);
			int remaining = Mathf.Abs(xDistance - yDistance);
			return MOVE_DIAGONAL_COST * mDistance + MOVE_STRAIGHT_COST * remaining;
		}
		/// <summary> 获得最小f成本 </summary>
		public DataMapUnit GetLowestFCostNode(List<DataMapUnit> openList) {
			DataMapUnit lowestFCostNode = openList[0];
			for (int i = 0; i < openList.Count; i++) {
				if (openList[i].FCost >= lowestFCostNode.FCost) { continue; }
				lowestFCostNode = openList[i];
			}
			return lowestFCostNode;
		}
		/// <summary> 计算临近节点 </summary>
		public void CalculateNeighbour(List<DataMapUnit> openList, List<DataMapUnit> closeList,
			DataMapUnit currentNode, DataMapUnit endNode, bool isCornerWalkable) {
			List<DataMapUnit> neighbourList = FindConnected(currentNode.x, currentNode.y);
			foreach (DataMapUnit neighbourNode in neighbourList) {
				//如果临近节点在关闭列表则跳过
				if (closeList.Contains(neighbourNode)) { continue; }
				//如果节点不可通行则添加到关闭列表
				if (!neighbourNode.IsWalkable && neighbourNode != endNode) {
					closeList.Add(neighbourNode);
					continue;
				}
				//计算阻挡
				if (!isCornerWalkable && CornerWalkable(currentNode, neighbourNode)) { continue; }

				//计算成本
				int tentativeGCost = currentNode.GCost + CalculateDistanceCost(currentNode, neighbourNode);
				if (tentativeGCost >= neighbourNode.GCost) { continue; }
				neighbourNode.cameFromNode = currentNode;
				neighbourNode.GCost = tentativeGCost;
				neighbourNode.HCost = CalculateDistanceCost(neighbourNode, endNode);
				neighbourNode.CalculateFCost();
				if (!openList.Contains(neighbourNode)) { openList.Add(neighbourNode); }
			}
		}
		/// <summary> 计算阻挡 </summary>
		public bool CornerWalkable(DataMapUnit currentNode, DataMapUnit neighbourNode) {
			if (CalculateDistanceCost(currentNode, neighbourNode) != MOVE_DIAGONAL_COST) { return false; }
			int x = neighbourNode.x - currentNode.x;
			int y = neighbourNode.y - currentNode.y;
			DataMapUnit a = unitArray[currentNode.x + x, currentNode.y];
			DataMapUnit b = unitArray[currentNode.x, currentNode.y + y];
			return !a.IsWalkable || !b.IsWalkable;
		}
		/// <summary> 返回最终路径 </summary>
		public List<Vector3> CalculatePath(DataMapUnit endNode) {
			List<Vector3> finalPath = new List<Vector3>();
			DataMapUnit currentNode = endNode;
			while (currentNode.cameFromNode != null) {
				finalPath.Add(GetWorldPosition(currentNode.x, currentNode.y));
				currentNode = currentNode.cameFromNode;
			}
			finalPath.Add(GetWorldPosition(currentNode.x, currentNode.y));
			finalPath.Reverse();
			return finalPath;
		}
	}
}
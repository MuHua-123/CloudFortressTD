using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 地图单元数据
	/// </summary>
	public class DataMapUnit {
		/// <summary> X坐标 </summary>
		public readonly int x;
		/// <summary> Y坐标 </summary>
		public readonly int y;

		/// <summary> 代价 </summary>
		public int GCost = 0;
		/// <summary> 代价 </summary>
		public int HCost = 0;
		/// <summary> 代价 </summary>
		public int FCost = 0;
		/// <summary> 来自节点 </summary>
		public DataMapUnit cameFromNode = null;

		/// <summary> 地图单元空间 </summary>
		public IMapUnitSpace mapSpace = null;

		/// <summary> 是否可以行走 </summary>
		public bool IsWalkable => mapSpace != null && mapSpace.IsWalkable;

		public DataMapUnit(int x, int y) { this.x = x; this.y = y; }

		/// <summary> 初始化寻路成本 </summary>
		public void InitializationCost() {
			GCost = int.MaxValue;
			CalculateFCost();
			cameFromNode = null;
		}
		/// <summary> 计算寻路成本 </summary>
		public void CalculateFCost() {
			FCost = GCost + HCost;
		}
	}
}
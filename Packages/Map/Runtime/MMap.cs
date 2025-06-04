using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 地图 - 模块
	/// </summary>
	public abstract class MMap {

		/// <summary> 世界坐标转换地图坐标 </summary>
		public abstract bool TryWorldPosition(Vector3 worldPosition, out Vector3 position);

		/// <summary> 获取地图单元 </summary>
		public abstract bool TryGetMapUnit(Vector3 worldPosition, out MMapUnit unit);

		/// <summary> 查询地图路径 </summary>
		public abstract bool FindPath(Vector3 sp, Vector3 ep, bool isCornerWalkable, out List<Vector3> vectorPath);
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 地图模块
/// </summary>
public abstract class ModuleMap {

	/// <summary> 世界坐标转换地图坐标 </summary>
	public abstract bool TryWorldPosition(Vector3 worldPosition, out Vector3 position);

}

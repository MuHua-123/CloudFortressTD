using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 生产 - 常量
/// </summary>
public abstract class ConstSpawn : ScriptableObject {
	/// <summary> 获取生产数据 </summary>
	public abstract DataSpawn GetSpawn(float startTime);
}

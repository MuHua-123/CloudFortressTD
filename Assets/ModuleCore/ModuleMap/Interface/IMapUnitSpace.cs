using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 地图单元空间
/// </summary>
public interface IMapUnitSpace {
	/// <summary> 是否可以行走 </summary>
	public bool IsWalkable { get; }
}

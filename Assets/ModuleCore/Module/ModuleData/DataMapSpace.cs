using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 地图空间
/// </summary>
public class DataMapSpace : IMapUnitSpace {

	public Transform building;

	public bool IsWalkable => building == null;
}

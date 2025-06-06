using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 地图空间 - 数据类
/// </summary>
public class DataMapSpace : IMapUnitSpace {

	public Transform building;

	public bool IsWalkable => building == null;

	public DataMapSpace() { }

	public DataMapSpace(Transform building) { this.building = building; }
}

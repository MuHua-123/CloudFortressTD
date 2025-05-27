using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuHua {
	/// <summary>
	/// 地图空间
	/// </summary>
	public class DataMapSpace : IMapUnitSpace {

		public Transform building;

		public bool IsWalkable => building == null;

		public DataMapSpace() { }

		public DataMapSpace(Transform building) { this.building = building; }
	}
}
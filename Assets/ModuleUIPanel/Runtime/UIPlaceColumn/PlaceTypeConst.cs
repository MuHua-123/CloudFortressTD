using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 放置类型
/// </summary>
[CreateAssetMenu(fileName = "PlaceObjectTypeConst", menuName = "MuHua/放置类型")]
public class PlaceTypeConst : ScriptableObject {
	/// <summary> 放置对象 </summary>
	public List<PlaceObject> placeObjects;

	/// <summary> 转换类型 </summary> 
	public PlaceType To() {
		PlaceType type = new PlaceType();
		type.name = name;
		type.placeObjects = placeObjects;
		return type;
	}
}

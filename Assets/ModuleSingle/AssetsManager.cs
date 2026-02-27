using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 资源管理器
/// </summary>
public class AssetsManager : ModuleSingle<AssetsManager> {
	/// <summary> 放置类型 </summary>
	public List<PlaceTypeConst> placeTypeConsts;

	public List<PlaceType> placeTypes = new List<PlaceType>();

	[HideInInspector]
	/// <summary> 全部对象 </summary>
	public List<PlaceObject> allObjects = new List<PlaceObject>();

	protected override void Awake() {
		NoReplace(false);

		placeTypes = new List<PlaceType>();
		allObjects = new List<PlaceObject>();
		placeTypeConsts.ForEach(To);
	}

	/// <summary> 对象查询 </summary> 
	public PlaceObject Find(string guid) => allObjects.FirstOrDefault(o => o.guid == guid);

	/// <summary> 转换器 </summary> 
	private void To(PlaceTypeConst typeConst) {
		placeTypes.Add(typeConst.To());
		allObjects.AddRange(typeConst.placeObjects);
	}
}

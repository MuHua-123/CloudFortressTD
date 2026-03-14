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

	[Header("场景")]
	/// <summary> 经典模式 </summary>
	public List<SceneConst> classic;

	public List<PlaceType> placeTypes = new List<PlaceType>();
	/// <summary> 经典模式 - 场景数据 </summary>
	public List<SceneData> classicSceneData = new List<SceneData>();

	[HideInInspector]
	/// <summary> 全部对象 </summary>
	public List<PlaceObject> allObjects = new List<PlaceObject>();

	protected override void Awake() {
		NoReplace(false);

		placeTypes = new List<PlaceType>();
		allObjects = new List<PlaceObject>();
		placeTypeConsts.ForEach(To);

		classic.ForEach(obj => classicSceneData.Add(obj.To()));
	}

	/// <summary> 对象查询 </summary> 
	public PlaceObject Find(string guid) => allObjects.FirstOrDefault(o => o.guid == guid);

	/// <summary> 转换器 </summary> 
	private void To(PlaceTypeConst typeConst) {
		placeTypes.Add(typeConst.To());
		allObjects.AddRange(typeConst.placeObjects);
	}
}

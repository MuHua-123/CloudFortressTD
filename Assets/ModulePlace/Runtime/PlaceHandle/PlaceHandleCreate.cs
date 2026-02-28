using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 创建处理器
/// </summary>
public class PlaceHandleCreate : ModuleSingle<PlaceHandleCreate> {

	/// <summary> 预览物体 </summary>
	[HideInInspector] public PlaceObject preview;
	/// <summary> 放置创建 </summary>
	[HideInInspector] public PlaceCreate placeCreate;

	/// <summary> 生成器 </summary>
	private VisualGenerator<PlaceObject> Generator => ModuleVisual.I.GeneratorPlaceObject;

	protected override void Awake() => NoReplace(false);

	/// <summary> 创建开始 </summary>
	public void CreateStart(PlaceObject placeObject) {
		if (placeObject == null) { CreateCancel(); return; }
		Generator.UpdateVisual(ref preview, placeObject.transform);
		if (!preview.Try(out placeCreate)) { return; }
		placeCreate?.CreateStart();
	}
	/// <summary> 取消创建 </summary>
	public void CreateCancel() {
		placeCreate?.CreateCancel();
		Generator.ReleaseVisual(preview);
		preview = null;
		placeCreate = null;
	}
	/// <summary> 完成创建 </summary>
	public void CreateComplete() {
		preview = null;
		placeCreate = null;
	}

	/// <summary> 更新 </summary>
	public void Update() => placeCreate?.CreateUpdate();
	/// <summary> 按下 </summary>
	public void Down() => placeCreate?.CreateDown();
	/// <summary> 抬起 </summary>
	public void Up() => placeCreate?.CreateUp();
}

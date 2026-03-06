using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// UI窗口 - 管理器
/// </summary>
public class UIWindowManager : ModuleUISingle<UIWindowManager> {
	// /// <summary> 撤销模板 </summary>
	// public VisualTreeAsset UndoTemplate;
	// /// <summary> 路径模板 </summary>
	// public VisualTreeAsset RouteTemplate;
	// /// <summary> 路径点模板 </summary>
	// public VisualTreeAsset WaypointTemplate;
	// /// <summary> 材质模板 </summary>
	// public VisualTreeAsset MaterialTemplate;
	// /// <summary> 图层模板 </summary>
	// public VisualTreeAsset LayerTemplate;
	// /// <summary> 图层对象模板 </summary>
	// public VisualTreeAsset LayerObjTemplate;

	// public UICommonWindow commonWindow;
	// public UILayerWindow layerWindow;
	// public UIMaterialWindow materialWindow;

	public override VisualElement Element => root.Q<VisualElement>("WindowManager");

	// public VisualElement CommonWindow => Q<VisualElement>("CommonWindow");
	// public VisualElement LayerWindow => Q<VisualElement>("LayerWindow");
	// public VisualElement MaterialWindow => Q<VisualElement>("MaterialWindow");

	protected override void Awake() {
		NoReplace(false);
		// commonWindow = new UICommonWindow(CommonWindow, root);
		// layerWindow = new UILayerWindow(LayerWindow, root);
		// materialWindow = new UIMaterialWindow(MaterialWindow, root);
	}
}

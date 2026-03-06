using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 加载页面 - 管理器
/// </summary>
public class UILoadingManager : ModuleUISingle<UILoadingManager> {

	public override VisualElement Element => root.Q<VisualElement>("LoadingManager");

	protected override void Awake() {
		NoReplace(false);
	}
}

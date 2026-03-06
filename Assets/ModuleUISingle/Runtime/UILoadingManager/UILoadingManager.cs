using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 加载页面 - 管理器
/// </summary>
public class UILoadingManager : ModuleUISingle<UILoadingManager> {

	public UILoading loading;

	public override VisualElement Element => root.Q<VisualElement>("LoadingManager");

	public VisualElement Loading => Q<VisualElement>("Loading");

	protected override void Awake() {
		NoReplace(false);

		loading = new UILoading(Loading, root);

		SceneSystem.OnProgress = (active, value) => loading.Settings(active, value, "加载中...");
	}
}

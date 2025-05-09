using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// UI模块
/// </summary>
public class ModuleUI : ModuleSingle<ModuleUI> {
	public static DataPage page;
	public static event Action<DataPage> OnJumpPage;

	public UIDocument document;// 绑定文档

	/// <summary> 根目录文档 </summary>
	public VisualElement root => document.rootVisualElement;

	protected override void Awake() => NoReplace();

	/// <summary> 跳转页面 </summary>
	public static void Jump(DataPage pageType) => OnJumpPage?.Invoke(pageType);
}

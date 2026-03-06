using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// UI模块
/// </summary>
public class ModuleUI : ModuleUISingle<ModuleUI> {
	/// <summary> 当前页面 </summary>
	public static Page Current;
	/// <summary> 回退页面 </summary>
	public static Page BackPage;
	/// <summary> 控件列表 </summary>
	public static List<UIControl> controls = new List<UIControl>();
	/// <summary> 页面跳转事件 </summary>
	public static event Action<Page> OnJumpPage;

	/// <summary> 跳转页面 </summary>
	public static void Settings(Page pageType) {
		BackPage = Current;
		Current = pageType;
		OnJumpPage?.Invoke(Current);
	}
	/// <summary> 回退页面 </summary>
	public static void Back() {
		Current = BackPage;
		OnJumpPage?.Invoke(Current);
	}
	/// <summary> 添加控件 </summary>
	public static void AddControl(UIControl control) {
		controls.Add(control);
	}
	/// <summary> 移除控件 </summary>
	public static void RemoveControl(UIControl control) {
		controls.Remove(control);
	}

	public override VisualElement Element => document.rootVisualElement;

	protected override void Awake() => NoReplace();

	private void Update() => controls.ForEach(control => control.Update());

	private void OnDestroy() => controls.ForEach(control => control.Dispose());
}
/// <summary>
/// 页面
/// </summary>
public enum Page {
	/// <summary> 无 </summary>
	None,
	/// <summary> 主页面 </summary>
	Home,
	/// <summary> 游戏设置 </summary>
	Settings,

	/// <summary> 经典模式 </summary>
	Classic,
	/// <summary> 经典模式 - 场景选择 </summary>
	ClassicScene,
	/// <summary> 经典模式 - 战斗场景 </summary>
	ClassicBattle,
	/// <summary> 经典模式 - 游戏暂停 </summary>
	ClassicPause,



	/// <summary> 菜单面 </summary>
	Menu,
	/// <summary> 场景选择 </summary>
	Scene,
	/// <summary> 准备游戏 </summary>
	Prepare,
	/// <summary> 战斗页面 </summary>
	Battle,
	/// <summary> 结算页面 </summary>
	Settlement,
}

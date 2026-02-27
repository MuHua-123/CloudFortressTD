using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 标准页面
/// </summary>
public abstract class UIStandardPage : ModuleUIPage {

	public virtual void Awake() {
		ModuleUI.OnJumpPage += ModuleUI_OnJumpPage;
	}
	public virtual void OnDestroy() {
		ModuleUI.OnJumpPage -= ModuleUI_OnJumpPage;
	}

	protected abstract void ModuleUI_OnJumpPage(Page page);
}

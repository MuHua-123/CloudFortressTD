using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// UI弹出 - 管理器
/// </summary>
public class UIPopupManager : ModuleUISingle<UIPopupManager> {

	public UIMessage1 message1;
	public UIMessage2 message2;
	public UIMessage3 message3;

	public override VisualElement Element => root.Q<VisualElement>("PopupManager");

	public VisualElement Message1 => Q<VisualElement>("Message1");
	public VisualElement Message2 => Q<VisualElement>("Message2");
	public VisualElement Message3 => Q<VisualElement>("Message3");

	protected override void Awake() {
		NoReplace(false);
		message1 = new UIMessage1(Message1);
		message2 = new UIMessage2(Message2);
		message3 = new UIMessage3(Message3);
	}
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 消息页面3
/// </summary>
public class UIMessage3 : ModuleUIPanel {

	private Action callback1;
	private Action callback2;

	public Label Content => Q<Label>("Content");
	public Button Button1 => Q<Button>("Button1");// 确认
	public Button Button2 => Q<Button>("Button2");// 取消

	public UIMessage3(VisualElement element) : base(element) {
		Button1.clicked += () => { callback1?.Invoke(); Settings(false); };
		Button2.clicked += () => { callback2?.Invoke(); Settings(false); };
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="active"></param>
	/// <param name="value"></param>
	/// <param name="callback1">确认的回调</param>
	/// <param name="callback2">取消的回调</param>
	public void Settings(bool active, string value = "", Action callback1 = null, Action callback2 = null) {
		element.EnableInClassList("document-page-hide", !active);
		Content.text = value;
		this.callback1 = callback1;
		this.callback2 = callback2;
	}
}

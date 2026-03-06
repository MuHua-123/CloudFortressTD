using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 消息页面1
/// </summary>
public class UIMessage1 : ModuleUIPanel {

	public Label Content => Q<Label>("Content");

	public UIMessage1(VisualElement element) : base(element) { }

	/// <summary>
	/// 设置消息内容
	/// </summary>
	/// <param name="active"></param>
	/// <param name="value"></param>
	public void Settings(bool active, string value = "") {
		element.EnableInClassList("document-page-hide", !active);
		Content.text = value;
	}
}

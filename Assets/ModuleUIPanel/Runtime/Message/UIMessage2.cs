using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 消息页面2
/// </summary>
public class UIMessage2 : ModuleUIPanel {

	private Action callback;

	public Label Content => Q<Label>("Content");
	public Button Button => Q<Button>("Button");

	public UIMessage2(VisualElement element) : base(element) {
		Button.clicked += () => { callback?.Invoke(); Settings(false); };
	}

	public void Settings(bool active) {
		element.EnableInClassList("document-page-hide", !active);
		callback = null;
	}
	public void Settings(bool active, string value = "", Action callback = null) {
		element.EnableInClassList("document-page-hide", !active);
		Content.text = value;
		this.callback = callback;
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 按钮1
/// </summary>
public class UIButton1 : ModuleUIPanel {
	/// <summary> 默认样式 </summary>
	public const string DEFAULT = "button1-d";
	/// <summary> 选中样式 </summary>
	public const string SELECTED = "button1-s";

	public event Action clicked;

	public string text {
		get => Label.text;
		set => Label.text = value;
	}

	public Label Label => Q<Label>("Label");
	public VisualElement Icon => Q<VisualElement>("Icon");
	public VisualElement Button => Q<VisualElement>("Button");

	public UIButton1(VisualElement element, string name, Action action = null) : base(element) {
		text = name;
		if (action != null) { clicked += action; }

		element.RegisterCallback<MouseOverEvent>(MouseOver);
		element.RegisterCallback<MouseLeaveEvent>(MouseLeave);
		element.RegisterCallback<ClickEvent>((evt) => clicked?.Invoke());
	}

	private void MouseOver(MouseOverEvent evt) {
		Icon.EnableInClassList(DEFAULT, true);
		Label.EnableInClassList(DEFAULT, true);
		Button.EnableInClassList(DEFAULT, false);

		Icon.EnableInClassList(SELECTED, false);
		Label.EnableInClassList(SELECTED, false);
		Button.EnableInClassList(SELECTED, true);
	}
	private void MouseLeave(MouseLeaveEvent evt) {
		Icon.EnableInClassList(DEFAULT, false);
		Label.EnableInClassList(DEFAULT, false);
		Button.EnableInClassList(DEFAULT, true);

		Icon.EnableInClassList(SELECTED, true);
		Label.EnableInClassList(SELECTED, true);
		Button.EnableInClassList(SELECTED, false);
	}
}

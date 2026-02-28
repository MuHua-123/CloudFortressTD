using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 放置对象面板
/// </summary>
public class UIPlaceObject : ModuleUIItem<PlaceObject> {

	public Label Name => Q<Label>("Name");
	public VisualElement Icon => Q<VisualElement>("Icon");
	public VisualElement button => Q<VisualElement>("Button");

	public UIPlaceObject(PlaceObject value, VisualElement element) : base(value, element) {
		Name.text = value.name;
		if (value.preview == null) {
			Texture2D texture = PreviewSystem.GetPreview(value.transform);
			Icon.style.backgroundImage = new StyleBackground(texture);
		}
		else {
			Icon.style.backgroundImage = new StyleBackground(value.preview);
		}
		element.RegisterCallback<ClickEvent>(evt => Select());
	}

	public override void DefaultState() {
		button.EnableInClassList("place-button-s", false);
	}
	public override void SelectState() {
		PlaceHandleCreate.I.CreateStart(value);
		button.EnableInClassList("place-button-s", true);
	}
}

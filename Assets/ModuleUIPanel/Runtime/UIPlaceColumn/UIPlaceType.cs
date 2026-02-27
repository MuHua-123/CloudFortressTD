using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 放置类型 - UI项
/// </summary>
public class UIPlaceType : ModuleUIItem<PlaceType> {

	public UIPlaceColumn parent;
	public Button Button => Q<Button>("Button");

	public UIPlaceType(PlaceType value, VisualElement element, UIPlaceColumn parent) : base(value, element) {
		this.parent = parent;
		Button.text = value.name;
		Button.clicked += Select;
		value.element = element;
	}
	public override void DefaultState() {
		Button.EnableInClassList("place-type-button-s", false);
	}
	public override void SelectState() {
		parent.Settings(value);
		Button.EnableInClassList("place-type-button-s", true);
	}
}

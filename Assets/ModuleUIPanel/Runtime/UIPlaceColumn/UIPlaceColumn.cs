using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 放置对象栏
/// </summary>
public class UIPlaceColumn : ModuleUIPanel {

	public ModuleUIItems<UIPlaceObject, PlaceObject> items;
	public UISlideButton<UIPlaceType, PlaceType> placeTypes;

	public VisualElement Container => Q<VisualElement>("Container");
	public VisualElement SlideButton => Q<VisualElement>("SlideButton");

	public UIPlaceColumn(VisualElement element, VisualElement canvas, VisualTreeAsset templateAsset1, VisualTreeAsset templateAsset2) : base(element) {
		items = new ModuleUIItems<UIPlaceObject, PlaceObject>(Container, templateAsset1,
		(data, element) => new UIPlaceObject(data, element));

		placeTypes = new UISlideButton<UIPlaceType, PlaceType>(SlideButton, canvas, templateAsset2,
		(data, element) => new UIPlaceType(data, element, this));
		ModuleUI.AddControl(placeTypes);
	}

	/// <summary> 初始化 </summary>
	public void Initial(List<PlaceType> list) {
		placeTypes.Create(list);
		placeTypes.SelectFirst();
	}
	/// <summary> 设置类型 </summary>
	public void Settings(PlaceType type) {
		items.Create(type.placeObjects);
	}
}

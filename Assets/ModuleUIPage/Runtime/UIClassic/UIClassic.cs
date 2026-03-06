using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// 经典塔防
/// </summary>
public class UIClassic : UIStandardPage {
	/// <summary> 放置类型 </summary>
	public VisualTreeAsset PlaceTypeTemplate;
	/// <summary> 放置模板 </summary>
	public VisualTreeAsset PlaceObjectTemplate;

	public UIPlaceColumn placeColumn;

	public override VisualElement Element => root.Q<VisualElement>("Classic");

	public VisualElement PlaceColumn => Q<VisualElement>("PlaceColumn");

	public override void Awake() {
		base.Awake();
		placeColumn = new UIPlaceColumn(PlaceColumn, root, PlaceObjectTemplate, PlaceTypeTemplate);
	}

	protected override void ModuleUI_OnJumpPage(Page page) {
		bool isDisable = page != Page.Classic;
		Element.EnableInClassList("document-page-hide", isDisable);
		if (isDisable) { return; }
		placeColumn.Initial(AssetsManager.I.placeTypes);
	}
}

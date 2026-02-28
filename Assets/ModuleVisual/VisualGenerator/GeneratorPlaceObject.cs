using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 放置对象 - 可视化生成器
/// </summary>
public class GeneratorPlaceObject : VisualGenerator<PlaceObject> {
	public override PlaceObject CreateVisual(Transform original) {
		PlaceObject placeObject = Create<PlaceObject>(original, transform);
		return placeObject;
	}
	public override void UpdateVisual(ref PlaceObject visual, Transform original) {
		if (visual != null) { ReleaseVisual(visual); }
		visual = CreateVisual(original);
	}
	public override void ReleaseAllVisual() {
		foreach (Transform item in transform) { Destroy(item.gameObject); }
	}
	public override void ReleaseVisual(PlaceObject visual) {
		if (visual != null) { Destroy(visual.gameObject); }
	}
}

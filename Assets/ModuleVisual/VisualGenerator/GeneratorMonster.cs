using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物 - 可视化生成器
/// </summary>
public class GeneratorMonster : VisualGenerator<PlaceObjectMonster> {
	public override PlaceObjectMonster CreateVisual(Transform original) {
		PlaceObjectMonster placeObject = Create<PlaceObjectMonster>(original, transform);
		return placeObject;
	}
	public override void UpdateVisual(ref PlaceObjectMonster visual, Transform original) {
		if (visual != null) { ReleaseVisual(visual); }
		visual = CreateVisual(original);
	}
	public override void ReleaseAllVisual() {
		foreach (Transform item in transform) { Destroy(item.gameObject); }
	}
	public override void ReleaseVisual(PlaceObjectMonster visual) {
		if (visual != null) { Destroy(visual.gameObject); }
	}
}

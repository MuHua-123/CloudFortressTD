using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 炮塔 - 生成器
/// </summary>
public class GeneratorHTurret : VisualGenerator<HTurret> {

	public Transform space;

	public override HTurret CreateVisual(Transform original) {
		return Create<HTurret>(original, space);
	}

	public override void UpdateVisual(ref HTurret visual, Transform original) {
		ReleaseVisual(visual);
		visual = CreateVisual(original);
	}

	public override void ReleaseVisual(HTurret visual) {
		if (visual != null) { Destroy(visual.gameObject); }
	}

}

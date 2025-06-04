using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 基础炮塔 - 生成器
/// </summary>
public class GeneratorTurretBasic : VisualGenerator<HTurret> {

	public Transform space;

	public override void CreateVisual(ref HTurret visual, Transform original) {
		ReleaseVisual(visual);
		visual = Create<HTurret>(original, space);
	}

	public override void ReleaseVisual(HTurret visual) {
		if (visual != null) { Destroy(visual.gameObject); }
	}
}

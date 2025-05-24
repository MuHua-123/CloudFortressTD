using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 基础炮塔 - 生成器
/// </summary>
public class GeneratorTurretBasic : VisualGenerator<TurretBasic> {

	public Transform space;

	public override void CreateVisual(ref TurretBasic visual, Transform original) {
		ReleaseVisual(visual);
		visual = Create<TurretBasic>(original, space);
	}

	public override void ReleaseVisual(TurretBasic visual) {
		if (visual != null) { Destroy(visual.gameObject); }
	}
}

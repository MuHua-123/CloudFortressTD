using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 子弹 - 生成器
/// </summary>
// public class GeneratorHBullet : VisualGenerator<HBullet> {

// 	public Transform space;

// 	public override HBullet CreateVisual(Transform original) {
// 		return Create<HBullet>(original, space);
// 	}

// 	public override void UpdateVisual(ref HBullet visual, Transform original) {
// 		ReleaseVisual(visual);
// 		visual = CreateVisual(original);
// 	}

// 	public override void ReleaseVisual(HBullet visual) {
// 		if (visual != null) { Destroy(visual.gameObject); }
// 	}
// }

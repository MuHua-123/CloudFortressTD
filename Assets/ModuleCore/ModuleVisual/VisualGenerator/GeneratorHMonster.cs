using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物 - 生成器
/// </summary>
public class GeneratorHMonster : VisualGenerator<HMonster> {

	public Transform space;

	public override HMonster CreateVisual(Transform original) {
		return Create<HMonster>(original, space);
	}
	public override void UpdateVisual(ref HMonster visual, Transform original) {
		ReleaseVisual(visual);
		visual = CreateVisual(original);
	}
	public override void ReleaseVisual(HMonster visual) {
		if (visual != null) { Destroy(visual.gameObject); }
	}
}

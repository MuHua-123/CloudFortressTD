using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 射线管理器
/// </summary>
public class RayManager : ModuleSingle<RayManager> {

	protected override void Awake() => NoReplace(false);

	#region 地面
	/// <summary> 地面图层 </summary>
	public LayerMask ground;
	/// <summary> 地面位置 </summary>
	public static bool GroundPosition(out Vector3 position) {
		Vector3 mousePosition = ModuleInput.mousePosition;
		return GroundPosition(mousePosition, out position);
	}
	/// <summary> 地面位置 </summary>
	public static bool GroundPosition(Vector2 screenPosition, out Vector3 position) {
		return RayTool.GetScreenToWorldPosition(screenPosition, out position, I.ground);
	}
	#endregion
}

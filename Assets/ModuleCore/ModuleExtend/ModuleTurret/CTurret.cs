using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using MuHua;

/// <summary>
/// 炮塔 - 控制器
/// </summary>
public abstract class CTurret : MonoBehaviour {

	public abstract DataTurret Data { get; }

	public abstract void Initial();

	public static CTurret AddControl(HTurret hTurret) {
		if (hTurret is HTurretStandard turretStandard) { return hTurret.gameObject.AddComponent<CTurretStandard>(); }
		return null;
	}
}

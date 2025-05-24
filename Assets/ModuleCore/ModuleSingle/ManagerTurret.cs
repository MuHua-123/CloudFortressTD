using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 炮塔 - 管理器
/// </summary>
public class ManagerTurret : ModuleSingle<ManagerTurret> {

	/// <summary> 炮塔预览 </summary>
	[HideInInspector] public TurretBasic preview;
	/// <summary> 炮塔列表 </summary>
	[HideInInspector] public List<TurretBasic> turretList = new List<TurretBasic>();

	private CameraController CameraController => ModuleCamera.CurrentCamera;

	protected override void Awake() => NoReplace(false);

	private void Update() {
		Vector3 worldPosition = CameraController.ScreenToWorldPosition(ModuleInput.mousePosition);
		if (!ManagerMap.TryWorldPosition(worldPosition, out Vector3 position)) { return; }
		transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * 20);
	}

	public void EnablePreview(TurretBasic turretBasic) {
		ModuleVisual.I.GeneratorTurretBasic.CreateVisual(ref preview, turretBasic.transform);
	}
}

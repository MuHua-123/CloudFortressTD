using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class InputGameState : OldModuleInput {
	private ModulePrefab<DataTurret> prefabTurret;
	private ModulePrefab<DataMonster> prefabMonster;

	/// <summary> 当前相机模块 </summary>
	public OldModuleCamera CurrentCamera => ModuleCore.CurrentCamera;
	/// <summary> 炮塔 DataTurret 数据处理器 </summary>
	public ModuleHandle<DataTurret> HandleTurret => ModuleCore.HandleTurret;

	#region 输入
	public void OnSelect(InputValue value) {
		if (ModuleInput.IsPointerOverUIObject) { return; }
		Vector3 screenPosition = value.Get<Vector2>();
		//选择炮塔
		CurrentCamera.ScreenToWorldObjectParent(screenPosition, out prefabTurret);
		DataTurret turret = prefabTurret != null ? prefabTurret.Value : null;
		HandleTurret.Change(turret);
		//渲染轮廓
		OutlineHandle.Clear();
		CurrentCamera.ScreenToWorldObjectParent(screenPosition, out FixedOutline outline);
		if (outline != null) { OutlineHandle.Add(outline.To()); }
	}
	public void OnPlaying(InputValue inputValue) {
		ModuleCore.HandleGameState.Current.PlaySpeed = 1;
		ModuleCore.HandleGameState.Change();
	}
	#endregion

}

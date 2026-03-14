using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MuHua;

/// <summary>
/// 快捷键 - 输入器
/// </summary>
public class InputShortcut : InputControl {

	protected override void ModuleInput_OnInputMode(InputMode mode) {
		Input.enabled = mode == InputMode.Standard;
	}

	#region 输入系统
	/// <summary> 菜单 </summary>
	public void OnMenu(InputValue inputValue) {
		if (inputValue.isPressed) { UIMenuManager.I.Close(); return; }
		if (InputCameraMove.isValid) { return; }
		// 打开右键菜单
		Vector3 position = UITool.GetMousePosition(ModuleUI.I.root);
		UIMenuManager.I?.Open(position, UIMenuManager.I.ContextMenu1);
	}
	// /// <summary> 新建 Ctrl + N </summary>
	// public void OnNew(InputValue inputValue) => RecordSystem.I.New();
	// /// <summary> 保存 Ctrl + S </summary>
	// public void OnSave(InputValue inputValue) => RecordSystem.I.Save();
	// /// <summary> 打开 Ctrl + O </summary>
	// public void OnOpen(InputValue inputValue) => RecordSystem.I.Load();
	// /// <summary> 退出 Ctrl + Q </summary>
	// public void OnQuit(InputValue inputValue) => Application.Quit();
	// /// <summary> 2D视图 Ctrl + 2 </summary>
	// public void OnOverlook(InputValue inputValue) => ModuleCamera.Settings(CameraMode.Overlook);
	// /// <summary> 3D视图 Ctrl + 3 </summary>
	// public void OnObserves(InputValue inputValue) => ModuleCamera.Settings(CameraMode.Observe);
	// /// <summary> 截图 Alt + s </summary>
	// public void OnScreenshot(InputValue inputValue) => SingleManager.I.Screenshot();
	// /// <summary> 撤销 Ctrl + Z </summary>
	// public void OnRollback(InputValue inputValue) {
	// 	ModuleUI.I.Element.Focus();
	// 	UndoSystem.I.Undo();
	// }
	// /// <summary> 恢复 Ctrl + Y </summary>
	// public void OnRecover(InputValue inputValue) {
	// 	ModuleUI.I.Element.Focus();
	// 	UndoSystem.I.Redo();
	// }

	// /// <summary> 删除对象 Delete </summary>
	// public void OnDelete(InputValue inputValue) => PlaceHandleSelect.I.Delete();
	// /// <summary> 多选对象 Delete </summary>
	// public void OnAccrual(InputValue inputValue) => PlaceHandleSelect.I.isAccrual = inputValue.isPressed;

	// /// <summary> 复制一个 Ctrl + D </summary>
	// public void OnQuickCopy(InputValue inputValue) => PlaceHandleCopy.I.QuickCopy();
	// /// <summary> 复制 Ctrl + C </summary>
	// public void OnCopy(InputValue inputValue) {
	// 	if (ModuleInput.IsPointerOverUIObject) { return; }
	// 	PlaceHandleCopy.I.Copy();
	// }
	// /// <summary> 粘贴 Ctrl + V </summary>
	// public void OnPaste(InputValue inputValue) {
	// 	if (ModuleInput.IsPointerOverUIObject) { return; }
	// 	PlaceHandleCopy.I.Paste();
	// }

	// /// <summary> 切换吸附 Tab </summary>
	// public void OnAdsorb(InputValue inputValue) => AdsorbManager.Switch();
	// /// <summary> 精细移动 方向键 </summary>
	// public void OnMoveDetail(InputValue inputValue) {
	// 	Vector2 vector = inputValue.Get<Vector2>();
	// 	direction = new Vector3(vector.x, 0, vector.y);
	// 	if (direction == Vector3.zero) { return; }
	// 	time = 0.1f;
	// 	PlaceHandleMove.I.MoveDetail(direction * 0.1f);
	// }
	#endregion
}

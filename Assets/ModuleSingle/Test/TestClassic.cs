using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 经典模式 - 测试
/// </summary>
public class TestClassic : ModuleSingle<TestClassic> {

	public MonsterWaveConst monsterWave;

	protected override void Awake() => NoReplace();

	private void Start() {
		Initial();
		ModuleUI.Settings(Page.Classic);
		ModuleInput.Settings(InputMode.Standard);
		ModuleCamera.Settings(CameraMode.Observe);
	}

	/// <summary> 初始化 </summary>
	public void Initial() {
		UIMenuManager.I.TopMenu = new MenuData { name = "顶部菜单" };
		// TopMenu.Add("文件/新建 (Ctrl + N)", RecordSystem.I.New);// Ctrl + N
		// TopMenu.Add("文件/保存 (Ctrl + S)", () => RecordSystem.I.Save());// Ctrl + S
		// TopMenu.Add("文件/另存为", () => RecordSystem.I.SaveAs());
		// TopMenu.Add("文件/打开 (Ctrl + O)", () => RecordSystem.I.Load());// Ctrl + O
		// TopMenu.Add("文件/导出", () => RecordSystem.I.SaveJson("json", "txt", "sql"));
		// TopMenu.Add("文件/导入", () => RecordSystem.I.LoadJson("json", "txt", "sql"));
		// TopMenu.Add("文件/导入模型", UIWindowManager.I.importerWindow.Open);

		// TopMenu.Add("文件/退出 (Ctrl + Q)", Application.Quit);// Ctrl + Q

		// TopMenu.Add("编辑/撤销 (Ctrl + Z)", UndoSystem.I.Undo);// Ctrl + Z
		// TopMenu.Add("编辑/恢复 (Ctrl + Y)", UndoSystem.I.Redo);// Ctrl + Y
		// TopMenu.Add("编辑/回撤历史", UIWindowManager.I.commonWindow.OpenUndo);
		// TopMenu.Add("编辑/车间设置", UIWindowManager.I.commonWindow.OpenWorkshop);
		// TopMenu.Add("编辑/路径编辑", UIWindowManager.I.commonWindow.OpenRoute);
		// TopMenu.Add("编辑/图层", UIWindowManager.I.layerWindow.Open);
		// TopMenu.Add("编辑/截图  (Alt + s)", SingleManager.I.Screenshot);// Alt + s

		// TopMenu.Add("帮助/操作指南", () => { UIPopupManager.I.manual.Settings(true); });
		// TopMenu.Add("帮助/检查更新", () => { ProgramSettings.CheckForUpdates(); });
		// TopMenu.Add("帮助/关于", () => { UIPopupManager.I.about.Settings(true); });

		UIMenuManager.I.ContextMenu1 = new MenuData { name = "右键菜单" };
		UIMenuManager.I.ContextMenu1.Add("Spawn/初始化", () => MonsterHandleSpawn.I.InitialSpawn(monsterWave));
		UIMenuManager.I.ContextMenu1.Add("Spawn/开始", () => MonsterHandleSpawn.I.Spawn());
		// ContextMenu1.Add("复制", PlaceHandleCopy.I.Copy);// Ctrl + C
		// ContextMenu1.Add("粘贴", PlaceHandleCopy.I.Paste);// Ctrl + V
		// ContextMenu1.Add("锁定", PlaceHandleLayer.I.Lock);
		// ContextMenu1.Add("解锁", PlaceHandleLayer.I.Unlock);
		// ContextMenu1.Add("隐藏", PlaceHandleLayer.I.Hide);

		UIMenuManager.I.ContextMenu2 = new MenuData { name = "右键菜单" };
		// ContextMenu2.Add("测量", PlaceHandleMeasure.I.Enable);
	}
}

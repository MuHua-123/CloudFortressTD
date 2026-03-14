using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

/// <summary>
/// UI快捷菜单
/// </summary>
public class UIMenuManager : ModuleUISingle<UIMenuManager> {
	/// <summary> 菜单模板 </summary>
	public VisualTreeAsset MenuPanel;
	/// <summary> 项目模板 </summary>
	public VisualTreeAsset MenuTemplate;

	/// <summary> 顶部菜单 </summary>
	public MenuData TopMenu;
	/// <summary> 右键菜单1 </summary>
	public MenuData ContextMenu1;
	/// <summary> 右键菜单2 </summary>
	public MenuData ContextMenu2;

	/// <summary> 控件列表 </summary>
	public static List<UIControl> controls = new List<UIControl>();

	public Vector3 MousePosition => UITool.GetMousePosition(Element);

	public override VisualElement Element => root.Q<VisualElement>("MenuManager");

	protected override void Awake() {
		NoReplace(false);
		Element.RegisterCallback<ClickEvent>(evt => Close());
	}

	private void Update() => controls.ForEach(control => control.Update());

	private void OnDestroy() => controls.ForEach(control => control.Dispose());

	/// <summary> 初始化 </summary>
	// public void Initial() {
	// 	TopMenu = new MenuData { name = "顶部菜单" };
	// 	// TopMenu.Add("文件/新建 (Ctrl + N)", RecordSystem.I.New);// Ctrl + N
	// 	// TopMenu.Add("文件/保存 (Ctrl + S)", () => RecordSystem.I.Save());// Ctrl + S
	// 	// TopMenu.Add("文件/另存为", () => RecordSystem.I.SaveAs());
	// 	// TopMenu.Add("文件/打开 (Ctrl + O)", () => RecordSystem.I.Load());// Ctrl + O
	// 	// TopMenu.Add("文件/导出", () => RecordSystem.I.SaveJson("json", "txt", "sql"));
	// 	// TopMenu.Add("文件/导入", () => RecordSystem.I.LoadJson("json", "txt", "sql"));
	// 	// TopMenu.Add("文件/导入模型", UIWindowManager.I.importerWindow.Open);

	// 	// TopMenu.Add("文件/退出 (Ctrl + Q)", Application.Quit);// Ctrl + Q

	// 	// TopMenu.Add("编辑/撤销 (Ctrl + Z)", UndoSystem.I.Undo);// Ctrl + Z
	// 	// TopMenu.Add("编辑/恢复 (Ctrl + Y)", UndoSystem.I.Redo);// Ctrl + Y
	// 	// TopMenu.Add("编辑/回撤历史", UIWindowManager.I.commonWindow.OpenUndo);
	// 	// TopMenu.Add("编辑/车间设置", UIWindowManager.I.commonWindow.OpenWorkshop);
	// 	// TopMenu.Add("编辑/路径编辑", UIWindowManager.I.commonWindow.OpenRoute);
	// 	// TopMenu.Add("编辑/图层", UIWindowManager.I.layerWindow.Open);
	// 	// TopMenu.Add("编辑/截图  (Alt + s)", SingleManager.I.Screenshot);// Alt + s

	// 	// TopMenu.Add("帮助/操作指南", () => { UIPopupManager.I.manual.Settings(true); });
	// 	// TopMenu.Add("帮助/检查更新", () => { ProgramSettings.CheckForUpdates(); });
	// 	// TopMenu.Add("帮助/关于", () => { UIPopupManager.I.about.Settings(true); });

	// 	ContextMenu1 = new MenuData { name = "右键菜单" };
	// 	ContextMenu1.Add("测量", null);
	// 	// ContextMenu1.Add("复制", PlaceHandleCopy.I.Copy);// Ctrl + C
	// 	// ContextMenu1.Add("粘贴", PlaceHandleCopy.I.Paste);// Ctrl + V
	// 	// ContextMenu1.Add("锁定", PlaceHandleLayer.I.Lock);
	// 	// ContextMenu1.Add("解锁", PlaceHandleLayer.I.Unlock);
	// 	// ContextMenu1.Add("隐藏", PlaceHandleLayer.I.Hide);

	// 	ContextMenu2 = new MenuData { name = "右键菜单" };
	// 	// ContextMenu2.Add("测量", PlaceHandleMeasure.I.Enable);
	// }

	#region 菜单操作
	/// <summary> 打开菜单 </summary>
	public void Open() => Open(MousePosition, TopMenu);
	/// <summary> 打开菜单 </summary>
	public void Open(Vector3 position, MenuData menu) {
		Close();
		UIMenuPanel menuPanel = Create();
		menuPanel.Settings(position, menu.menuItems);
		Element.EnableInClassList("document-page-hide", false);
	}
	/// <summary> 关闭菜单 </summary>
	public void Close() {
		controls.ForEach(control => control.Dispose());
		controls.Clear();
		Element.Clear();
		Element.EnableInClassList("document-page-hide", true);
	}
	/// <summary> 创建子菜单 </summary>
	public UIMenuPanel Create() {
		// 创建菜单元素
		VisualElement element = MenuPanel.Instantiate();
		element.EnableInClassList("menu", true);
		Element.Add(element);
		UIMenuPanel menuPanel = new UIMenuPanel(element, MenuTemplate);
		controls.Add(menuPanel);
		return menuPanel;
	}
	#endregion
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 菜单项目
/// </summary>
public class MenuData {
	/// <summary> 名称 </summary>
	public string name;
	/// <summary> 回调 </summary>
	public Action callback;
	/// <summary> 子菜单项 </summary>
	public List<MenuData> menuItems = new List<MenuData>();

	/// <summary> 添加菜单项(1级菜单/2级菜单/3级菜单) </summary> 
	public void Add(string name, Action callback) {
		string[] names = name.Split('/');
		MenuData item = Find(names[0], menuItems, true);
		for (int i = 1; i < names.Length; i++) {
			item = Find(names[i], item.menuItems, true);
		}
		item.callback = callback;
	}
	/// <summary> 移除菜单项(???/???/子级菜单) </summary>
	public void Remove(string name) {
		string[] names = name.Split('/');
		List<MenuData> menuItems = this.menuItems;
		MenuData item = Find(names[0], menuItems, false);
		for (int i = 1; i < names.Length; i++) {
			if (item == null) return;
			menuItems = item.menuItems;
			item = Find(names[i], menuItems, false);
		}
		menuItems.Remove(item);
	}

	/// <summary> 子项目查找 </summary> 
	private MenuData Find(string menu, List<MenuData> menuItems, bool isCreate) {
		MenuData item = menuItems.Find(obj => obj.name == menu);
		if (item != null || !isCreate) { return item; }
		item = new MenuData { name = menu };
		menuItems.Add(item);
		return item;
	}
}

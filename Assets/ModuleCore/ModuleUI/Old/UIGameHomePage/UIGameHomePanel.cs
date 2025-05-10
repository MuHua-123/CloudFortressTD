using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 游戏主页子页面
/// </summary>
//public abstract class UIGameHomePanel : ModulePage {
//    /// <summary> 游戏主页 </summary>
//    //public UIGameHomePage GameHome => ModuleUIPage as UIGameHomePage;
//    /// <summary> 打开方法 </summary>
//    public abstract void Open(GameHomeType type);
//}
/// <summary>
/// 主页类型
/// </summary>
public enum GameHomeType {
    Menu = 0,
    Level = 1
}
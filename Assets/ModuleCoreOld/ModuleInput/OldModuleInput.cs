using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 输入模块
/// </summary>
public abstract class OldModuleInput : MonoBehaviour {
	/// <summary> 可选初始化 </summary>
	protected virtual void Awake() { }
	/// <summary> 核心模块 </summary>
	protected virtual ModuleCore ModuleCore => ModuleCore.I;
}

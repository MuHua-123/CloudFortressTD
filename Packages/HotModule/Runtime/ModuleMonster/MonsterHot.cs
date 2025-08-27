using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物 - 热更数据
/// </summary>
public class MonsterHot : MonoBehaviour {
	/// <summary> 动画接口 </summary>
	public IMonsterFunc func;
	/// <summary> 动画触发 </summary>
	public virtual void Trigger(string value) => func?.Trigger(value);
}
/// <summary>
/// 动画事件接口
/// </summary>
public interface IMonsterFunc {
	/// <summary> 触发 </summary>
	public void Trigger(string value);
	/// <summary> 设置状态 </summary>
	public void SettingsState(string token, bool isTransition, bool isFloating, bool isInjured);
}
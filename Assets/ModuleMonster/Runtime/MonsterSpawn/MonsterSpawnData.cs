using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物生产数据
/// </summary>
public abstract class MonsterSpawnData {

	/// <summary> 是否结束生产 </summary>
	public abstract bool IsEnd { get; }

	/// <summary> 设置 </summary> 
	public abstract void Settings(Action<Transform> callback);
	/// <summary> 更新 </summary> 
	public abstract void Update();
}

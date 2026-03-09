using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 标准 - 怪物生产数据
/// </summary>
public class SpawnStandard : MonsterSpawnData {
	/// <summary> 数量 </summary>
	public int quantity;
	/// <summary> 间隔 </summary>
	public float interval;
	/// <summary> 预制 </summary>
	public Transform prefab;
	/// <summary> 生产回调 </summary>
	public Action<Transform> callback;

	/// <summary> 生产索引 </summary>
	private int index;
	/// <summary> 生产时间 </summary>
	private float countdown;

	public override bool IsEnd => index >= quantity;

	public override void Settings(Action<Transform> callback) => this.callback = callback;

	public override void Update() {
		// 结束
		if (index >= quantity) { return; }
		// 计时器
		countdown -= Time.deltaTime;
		if (countdown > 0) { return; }
		countdown = interval;
		// 生成
		index++;
		callback?.Invoke(prefab);
	}
}

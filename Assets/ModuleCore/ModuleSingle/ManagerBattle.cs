using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 战斗 - 管理器
/// </summary>
public class ManagerBattle : ModuleSingle<ManagerBattle> {
	/// <summary> 初始化事件 </summary>
	public static event Action OnInitial;
	/// <summary> 新的波次 </summary>
	public static event Action<int> OnNewWave;

	/// <summary> 金币 </summary>
	public int gold;
	/// <summary> 生命值 </summary>
	public int health;
	/// <summary> 波次 </summary>
	public Vector2Int wave;
	/// <summary> 波次间隔 </summary>
	public float interval;
	/// <summary> 倒计时 </summary>
	public float countdown;

	protected override void Awake() => NoReplace(false);

	/// <summary> 初始化 </summary>
	public void Initial() {
		// 查找设置对象
		if (!Utilities.FindObject(out BattleSettings settings)) { return; }

		gold = 1000;
		health = 20;
		wave = new Vector2Int(0, settings.maxWave);
		interval = settings.interval;
		countdown = 0;

		OnInitial?.Invoke();
	}

	private void Update() {
		countdown -= Time.deltaTime;
		if (countdown >= 0) { return; }
		countdown = interval;
		if (wave.x >= wave.y) { return; }
		wave.x++;
		OnNewWave?.Invoke(wave.x);
	}
}

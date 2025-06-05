using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using MuHua;

/// <summary>
/// 炮台资源管理
/// </summary>
public class AssetsTurret : ModuleSingle<AssetsTurret> {

	public static event Action OnChange;

	public const string Tag = "default";// aa查找的标签

	/// <summary> 全部炮塔 </summary>
	public List<HTurret> allTurrets;
	/// <summary> 使用中的炮塔 </summary>
	public List<HTurret> useTurrets;

	protected override void Awake() => Replace(false);

	/// <summary> 更新列表 </summary>
	public void UpdateConfig() {
		allTurrets = new List<HTurret>();
		Addressables.LoadAssetsAsync<ConstTurret>(Tag, UpdateConfig, true);
	}
	public void UpdateConfig(ConstTurret sceneConfig) {
		allTurrets.AddRange(sceneConfig.configs);
		OnChange?.Invoke();
	}
}

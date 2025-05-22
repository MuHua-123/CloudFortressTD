using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using MuHua;

/// <summary>
/// 炮台资源管理
/// </summary>
public class AssetsTurretConfig : ModuleSingle<AssetsTurretConfig> {

	public static event Action OnChange;

	public const string Tag = "default";// aa查找的标签

	public List<TurretBasic> turrets;

	public static List<TurretBasic> Datas => I.turrets;

	protected override void Awake() => Replace(false);

	/// <summary> 更新列表 </summary>
	public void UpdateConfig() {
		turrets = new List<TurretBasic>();
		Addressables.LoadAssetsAsync<ConstTurretConfig>(Tag, UpdateConfig, true);
	}
	public void UpdateConfig(ConstTurretConfig sceneConfig) {
		turrets.AddRange(sceneConfig.configs);
		OnChange?.Invoke();
	}
}

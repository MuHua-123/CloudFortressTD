using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using MuHua;

/// <summary>
/// 场景资源管理
/// </summary>
public class AssetsSceneConfig : ModuleSingle<AssetsSceneConfig> {

	public static event Action OnChange;

	public const string Tag = "default";// aa查找的标签

	public List<DataSceneConfig> sceneConfigs;

	public static List<DataSceneConfig> Datas => I.sceneConfigs;

	protected override void Awake() => Replace(false);

	/// <summary> 更新场景列表 </summary>
	public void UpdateConfig() {
		sceneConfigs = new List<DataSceneConfig>();
		Addressables.LoadAssetsAsync<ConstSceneConfig>(Tag, UpdateConfig, true);
	}
	public void UpdateConfig(ConstSceneConfig sceneConfig) {
		sceneConfigs.AddRange(sceneConfig.configs);
		OnChange?.Invoke();
	}
}

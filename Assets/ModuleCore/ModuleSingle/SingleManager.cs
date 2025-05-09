using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 游戏管理
/// </summary>
public class SingleManager : ModuleSingle<SingleManager> {

	public static DataSceneConfig sceneConfig;// 场景配置

	protected override void Awake() => NoReplace();

	/// <summary> 设置场景数据 </summary>
	public static void SetSceneConfig(DataSceneConfig sceneConfig) {
		SingleManager.sceneConfig = sceneConfig;
	}

	/// <summary> 开始游戏 </summary>
	public void StartGame() {
		StartCoroutine(IStartGame());
	}
	/// <summary> 开始游戏 </summary>
	public IEnumerator IStartGame() {
		// 加载场景
		yield return sceneConfig.ILoadScene(null);
		//  启动设置
		// SinglePlayer.I.CreateCharacter();
		ModuleUI.Jump(DataPage.None);
		// ModuleInput.I.EnablePreview();
		// ModuleCamera.I.EnableThirdPerson();
	}
}

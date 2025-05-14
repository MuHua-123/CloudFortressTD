using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using MuHua;

/// <summary>
/// 场景 - 管理器
/// </summary>
public class ManagerScene : ModuleSingle<ManagerScene> {

	/// <summary> 场景是否有效 </summary>
	public static bool isValid => I != null && I.sceneConfig != null && I.sceneConfig.scene != null;
	/// <summary> 场景加载完成 </summary>
	public static event Action OnComplete;

	/// <summary> 设置场景 </summary>
	public static void SetSceneConfig(DataSceneConfig sceneConfig) => I.sceneConfig = sceneConfig;
	/// <summary> 加载场景 </summary>
	public static void LoadScene(Action<float> progress) => I.StartCoroutine(I.ILoadScene(progress));

	private DataSceneConfig sceneConfig;// 场景配置

	protected override void Awake() => NoReplace(false);

	/// <summary> 加载场景 </summary>
	private IEnumerator ILoadScene(Action<float> progress) {
		// 检查场景数据
		if (sceneConfig == null || sceneConfig.scene == null) { Debug.LogError("无效场景!"); yield break; }
		// 创建加载句柄
		AsyncOperationHandle<SceneInstance> handle = sceneConfig.scene.LoadSceneAsync();
		// 协程加载
		while (!handle.IsDone) { yield return IHandleProgress(handle, progress); }
		//加载结束
		OnComplete?.Invoke();
	}
	/// <summary> 处理进度 </summary>
	private IEnumerator IHandleProgress(AsyncOperationHandle<SceneInstance> handle, Action<float> progress) {
		float downloadProgress = handle.GetDownloadStatus().Percent;
		float loadProgress = handle.PercentComplete;
		float totalProgress = (downloadProgress + loadProgress) / 2.0f;
		progress?.Invoke(totalProgress);
		if (handle.Status == AsyncOperationStatus.Failed) { Debug.LogError("无法加载场景!"); }
		yield return handle;
	}
}

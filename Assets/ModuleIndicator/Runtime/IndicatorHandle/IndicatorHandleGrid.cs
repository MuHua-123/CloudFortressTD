using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 格子 - 指示处理
/// </summary>
public class IndicatorHandleGrid : ModuleSingle<IndicatorHandleGrid> {

	public MeshRenderer meshRenderer;

	protected override void Awake() => NoReplace(false);

	/// <summary> 打开 </summary> 
	public void Open() {
		meshRenderer.gameObject.SetActive(true);
	}
	/// <summary> 关闭 </summary> 
	public void Close() {
		meshRenderer.gameObject.SetActive(false);
	}
	/// <summary> 设置 </summary> 
	public void Settings(Vector3 position) {
		Material material = meshRenderer.material;
		position.y = 0;
		material.SetVector("_Position", position);
	}
}

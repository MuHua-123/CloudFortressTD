using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 场景数据 - 常量
/// </summary>
[CreateAssetMenu(fileName = "SceneConst", menuName = "MuHua/场景数据")]
public class SceneConst : ScriptableObject {
	/// <summary> 场景预览 </summary>
	public Sprite preview;

	public SceneData To() {
		SceneData scene = new SceneData();
		scene.name = name;
		scene.preview = preview;
		return scene;
	}
}

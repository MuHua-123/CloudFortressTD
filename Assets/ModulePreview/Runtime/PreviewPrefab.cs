using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 预览预制件
/// </summary>
public class PreviewPrefab : MonoBehaviour {

	public Camera rendererCamera;
	public Transform parent;
	[HideInInspector]
	public RenderTexture renderTexture;

	private void Awake() {
		DestroyAll();
		renderTexture = PreviewSystem.GetRenderTexture();
		rendererCamera.allowHDR = false;
		rendererCamera.targetTexture = renderTexture;
		rendererCamera.clearFlags = CameraClearFlags.SolidColor;
		rendererCamera.backgroundColor = new Color(0, 0, 0, 0);
	}

	/// <summary> 获得预览 </summary> 
	public Texture2D GetPreview(Transform prefab, int width, int height) {
		// 设置预制件
		Transform temp = Instantiate(prefab, parent);
		// if (temp.Try(out PlaceBounds bounds)) { Normalized(temp, bounds); }
		// 渲染相机
		rendererCamera.Render();
		// 读取像素
		RenderTexture.active = renderTexture;
		Texture2D texture = new Texture2D(width, height, TextureFormat.RGBA32, false);
		texture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		texture.Apply();
		// 清理
		RenderTexture.active = null;
		DestroyImmediate(temp.gameObject);
		// 返回
		return texture;
	}

	/// <summary> 销毁对象 </summary>
	private void DestroyAll() {
		foreach (Transform item in parent) { DestroyImmediate(item.gameObject); }
	}
	/// <summary> 包围盒归一化 </summary>
	// private void Normalized(Transform temp, PlaceBounds bounds) {
	// 	Vector3 size = bounds.localSize;
	// 	float max = Mathf.Max(size.x, size.y, size.z);
	// 	float scale = 1 / max;
	// 	temp.localScale = new Vector3(scale, scale, scale);
	// 	temp.localPosition = bounds.localCenter * -scale;
	// }
}

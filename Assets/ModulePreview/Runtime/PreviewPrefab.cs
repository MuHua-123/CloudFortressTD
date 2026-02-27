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
		// 设置中心点
		BoundsWorld boundsWorld = new BoundsWorld();
		boundsWorld.Calculate(transform);
		Vector3 size = boundsWorld.size;
		Vector3 center = boundsWorld.center;
		float max = Mathf.Max(size.x, size.y, size.z);
		float scale = 1 / max;
		temp.localScale = new Vector3(scale, scale, scale);
		temp.localPosition = center * -scale;
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
		List<Transform> transforms = new List<Transform>();
		foreach (Transform item in parent) {
			if (item != null) { transforms.Add(item); }
		}
		for (int i = 0; i < transforms.Count; i++) {
			DestroyImmediate(transforms[i].gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 预览材质
/// </summary>
public class PreviewMaterial : MonoBehaviour {

	public Camera rendererCamera;
	public MeshRenderer meshRenderer;
	[HideInInspector]
	public RenderTexture renderTexture;

	private void Awake() {
		renderTexture = PreviewSystem.GetRenderTexture();
		rendererCamera.allowHDR = false;
		rendererCamera.targetTexture = renderTexture;
		rendererCamera.clearFlags = CameraClearFlags.SolidColor;
		rendererCamera.backgroundColor = new Color(0, 0, 0, 0);
	}

	/// <summary> 获得材质预览 </summary> 
	public Texture2D GetPreview(Material material, int width, int height) {
		// 设置材质
		meshRenderer.material = material;
		// 渲染相机
		rendererCamera.Render();
		// 读取像素
		RenderTexture.active = renderTexture;
		Texture2D texture = new Texture2D(width, height, TextureFormat.RGBA32, false);
		texture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		texture.Apply();
		// 清理
		RenderTexture.active = null;
		// 返回
		return texture;
	}
}

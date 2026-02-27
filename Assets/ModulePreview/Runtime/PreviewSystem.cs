using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

/// <summary>
/// 预览系统
/// </summary>
public class PreviewSystem : ModuleSingle<PreviewSystem> {

	/// <summary> 默认宽 </summary>
	public const int Width = 256;
	/// <summary> 默认高 </summary>
	public const int Height = 256;

	public PreviewMaterial previewMaterial;
	public PreviewPrefab previewPrefab;

	protected override void Awake() => NoReplace();

	/// <summary> 获取渲染纹理 </summary> 
	public static RenderTexture GetRenderTexture(int width = Width, int height = Height) {
		return new RenderTexture(width, height, 16, RenderTextureFormat.ARGB32);
	}

	/// <summary> 获得材质预览 </summary> 
	public static Texture2D GetPreview(Material material, int width = Width, int height = Height) {
		return I.previewMaterial.GetPreview(material, width, height);
	}
	/// <summary> 获得预制件预览 </summary> 
	public static Texture2D GetPreview(Transform prefab, int width = Width, int height = Height) {
		return I.previewPrefab.GetPreview(prefab, width, height);
	}
}

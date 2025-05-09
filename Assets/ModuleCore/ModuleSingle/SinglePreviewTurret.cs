using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using MuHua;

public class SinglePreviewTurret : MonoBehaviour {
	public Camera viewCamera;
	public Transform viewSpace;
	public List<FixedOutline> turrets;
	private bool isLock = false;
	private RenderTexture renderTexture;
	private Queue<FixedOutline> queue = new Queue<FixedOutline>();

	private void Awake() {
		renderTexture = new RenderTexture(512, 512, 16, RenderTextureFormat.ARGB32);
		viewCamera.targetTexture = renderTexture;
		for (int i = 0; i < turrets.Count; i++) { queue.Enqueue(turrets[i]); }
		OutlineHandle.Size = 15f;
	}
	private void Update() {
		if (queue.Count <= 0 || isLock) { return; }
		StartCoroutine(IGenerateTexture(queue.Dequeue()));
	}
	public void GenerateTexture() {
		Texture2D texture = RenderTextureToTexture2D(renderTexture);
		string name = Guid.NewGuid().ToString("N");
		byte[] bytes = texture.EncodeToPNG();
		string path = $"{SaveTool.PATH}/{name}.png";
		File.WriteAllBytes(path, bytes);
	}
	private IEnumerator IGenerateTexture(FixedOutline original) {
		isLock = true;
		foreach (Transform item in viewSpace) {
			Destroy(item.gameObject);
		}
		OutlineHandle.Clear();
		Transform temp = Instantiate(original.transform, viewSpace);
		temp.gameObject.SetActive(true);
		FixedOutline fixedOutline = temp.GetComponent<FixedOutline>();
		OutlineHandle.Add(fixedOutline.To());
		yield return new WaitForSeconds(1.0f);
		Texture2D texture = RenderTextureToTexture2D(renderTexture);
		string name = original.name;
		byte[] bytes = texture.EncodeToPNG();
		string path = $"{SaveTool.PATH}/{name}.png";
		File.WriteAllBytes(path, bytes);
		isLock = false;
	}
	private Texture2D RenderTextureToTexture2D(RenderTexture renderTexture) {
		int width = renderTexture.width;
		int height = renderTexture.height;
		Texture2D texture2D = new Texture2D(width, height, TextureFormat.ARGB32, false);
		RenderTexture.active = renderTexture;
		texture2D.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		texture2D.Apply();
		return GetTexture(texture2D);
	}
	private Texture2D GetTexture(Texture2D texture2D) {
		Color[] colors = texture2D.GetPixels();
		Texture2D target = new Texture2D(texture2D.width, texture2D.height);
		target.SetPixels(colors);
		target.Apply();
		return target;
	}
}

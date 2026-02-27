using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 世界边界
/// </summary>
public class BoundsWorld {
	/// <summary> 是否有边界 </summary>
	public bool hasBounds;
	/// <summary> 边界 </summary>
	public Bounds bounds;
	/// <summary> 边界大小 </summary>
	public Vector3 size = new Vector3(1, 1, 1);
	/// <summary> 边界中心 </summary>
	public Vector3 center;
	/// <summary> 变换 </summary>
	public Transform transform;

	/// <summary> 计算边界 </summary> 
	public void Calculate(Transform transform) {
		this.transform = transform;
		hasBounds = false;
		bounds = new Bounds();
		size = Vector3.one;
		center = Vector3.one;

		if (transform == null) { return; }
		MeshFilter[] meshFilters = transform.GetComponentsInChildren<MeshFilter>();
		for (int i = 0; i < meshFilters.Length; i++) { Calculate(meshFilters[i]); }

		Vector3 position = bounds.center - transform.position;

		Vector3 tempSize = hasBounds ? bounds.size : Vector3.one;
		Vector3 tempCenter = hasBounds ? position : Vector3.zero;
		size = ValueTool.Round(tempSize);
		center = ValueTool.Round(tempCenter);
	}
	/// <summary> 计算边界 </summary> 
	private void Calculate(MeshFilter meshFilter) {
		if (meshFilter.sharedMesh == null) { return; }
		Bounds b = CalculateBounds(meshFilter);
		if (hasBounds) { bounds.Encapsulate(b); return; }
		bounds = b; hasBounds = true;
	}
	/// <summary> 计算边界 </summary> 
	private Bounds CalculateBounds(MeshFilter meshFilter) {
		Mesh mesh = meshFilter.sharedMesh;
		Bounds meshBounds = mesh.bounds;
		Transform meshTransform = meshFilter.transform;

		Vector3[] vertices = BoundsVertex(meshBounds, meshTransform);

		// 计算新的包围盒
		Vector3 newMin = vertices[0];
		Vector3 newMax = vertices[0];
		for (int i = 1; i < vertices.Length; i++) {
			Vector3 worldPoint = vertices[i];
			newMin = Vector3.Min(newMin, worldPoint);
			newMax = Vector3.Max(newMax, worldPoint);
		}

		// 计算新的center和size（世界空间）
		Vector3 worldCenter = (newMin + newMax) * 0.5f;
		Vector3 worldSize = newMax - newMin;
		return new Bounds(worldCenter, worldSize);
	}
	/// <summary> 计算包围盒的8个顶点(世界空间) </summary> 
	private Vector3[] BoundsVertex(Bounds meshBounds, Transform meshTransform) {
		Vector3[] vertices = new Vector3[8];
		Vector3 min = meshBounds.min;
		Vector3 max = meshBounds.max;
		vertices[0] = meshTransform.TransformPoint(new Vector3(min.x, min.y, min.z));
		vertices[1] = meshTransform.TransformPoint(new Vector3(max.x, min.y, min.z));
		vertices[2] = meshTransform.TransformPoint(new Vector3(min.x, max.y, min.z));
		vertices[3] = meshTransform.TransformPoint(new Vector3(max.x, max.y, min.z));
		vertices[4] = meshTransform.TransformPoint(new Vector3(min.x, min.y, max.z));
		vertices[5] = meshTransform.TransformPoint(new Vector3(max.x, min.y, max.z));
		vertices[6] = meshTransform.TransformPoint(new Vector3(min.x, max.y, max.z));
		vertices[7] = meshTransform.TransformPoint(new Vector3(max.x, max.y, max.z));
		return vertices;
	}
}

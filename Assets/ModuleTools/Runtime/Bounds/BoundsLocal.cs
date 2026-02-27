using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 局部边界
/// </summary>
public class BoundsLocal {
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

		Vector3 localSize = hasBounds ? bounds.size : Vector3.one;
		Vector3 localCenter = hasBounds ? bounds.center : Vector3.zero;
		size = ValueTool.Round(localSize);
		center = ValueTool.Round(localCenter);
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

		// 将顶点变换到世界空间，然后再变换到当前transform的本地空间
		Bounds bounds = new Bounds();
		for (int i = 0; i < vertices.Length; i++) {
			Vector3 worldPoint = vertices[i];
			Vector3 localPoint = transform.InverseTransformPoint(worldPoint);
			bounds.Encapsulate(localPoint);
		}
		return bounds;
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

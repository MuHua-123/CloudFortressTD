using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 数值工具
/// </summary>
public static class ValueTool {

	/// <summary> 保留小数 </summary> 
	public static float Round(float value, float digits = 1000f) => Mathf.Round(value * digits) / digits;
	/// <summary> 保留小数 </summary> 
	public static Vector2 Round(Vector2 value, float digits = 1000f) {
		return new Vector3(
			Round(value.x, digits),
			Round(value.y, digits)
		);
	}
	/// <summary> 保留小数 </summary> 
	public static Vector3 Round(Vector3 value, float digits = 1000f) {
		return new Vector3(
			Round(value.x, digits),
			Round(value.y, digits),
			Round(value.z, digits)
		);
	}
	/// <summary> string转换float </summary> 
	public static float ParseFloat(this string value) {
		float.TryParse(value, out float newValue);
		return newValue;
	}

	/// <summary> Vector2 转换为字符串（用逗号分隔） </summary>
	public static string Vector2ToString(this Vector2 value, int decimals = 3) {
		float digits = Mathf.Pow(10f, decimals);
		Vector2 rounded = Round(value, digits);
		return $"{rounded.x},{rounded.y}";
	}
	/// <summary> 字符串转换为 Vector2 </summary>
	public static Vector2 ParseVector2(this string value) {
		if (string.IsNullOrEmpty(value)) { return Vector3.zero; }

		string[] parts = value.Split(',');
		if (parts.Length != 2) { return Vector3.zero; }

		float.TryParse(parts[0], out float x);
		float.TryParse(parts[1], out float y);

		return new Vector2(x, y);
	}

	/// <summary> Vector3 转换为字符串（用逗号分隔） </summary>
	public static string Vector3ToString(this Vector3 value, int decimals = 3) {
		float digits = Mathf.Pow(10f, decimals);
		Vector3 rounded = Round(value, digits);
		return $"{rounded.x},{rounded.y},{rounded.z}";
	}
	/// <summary> 字符串转换为 Vector3 </summary>
	public static Vector3 ParseVector3(this string value) {
		if (string.IsNullOrEmpty(value)) { return Vector3.zero; }

		string[] parts = value.Split(',');
		if (parts.Length != 3) { return Vector3.zero; }

		float.TryParse(parts[0], out float x);
		float.TryParse(parts[1], out float y);
		float.TryParse(parts[2], out float z);

		return new Vector3(x, y, z);
	}
}

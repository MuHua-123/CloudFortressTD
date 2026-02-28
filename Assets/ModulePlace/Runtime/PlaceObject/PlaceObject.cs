using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 放置物体
/// </summary>
public class PlaceObject : MonoBehaviour {
	/// <summary> 预览图 </summary>
	public Sprite preview;
	/// <summary> guid </summary>
	public string guid = System.Guid.NewGuid().ToString("N");
	/// <summary> 是否启用 </summary>
	public bool isEnable;

	/// <summary> 是否启用 </summary>
	public virtual bool IsEnable => isEnable;
}

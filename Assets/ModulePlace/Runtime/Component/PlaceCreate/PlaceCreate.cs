using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 放置创建
/// </summary>
public class PlaceCreate : MonoBehaviour {

	private Vector3 position;

	public PlaceObject PlaceObject => GetComponent<PlaceObject>();

	/// <summary> 开始创建 </summary>
	public virtual void CreateStart() {
		position = transform.position;
	}
	/// <summary> 取消创建 </summary>
	public virtual void CreateCancel() { }
	/// <summary> 创建完成 </summary>
	public virtual void CreateComplete() {
		transform.position = position;
		PlaceObject.isEnable = true;
		// 添加到图层
		// PlaceHandleLayer.I.AddLayerObject(this);
	}

	/// <summary> 更新创建 </summary>
	public virtual void CreateUpdate() {
		transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * 10);

		if (!RayManager.GroundPosition(out Vector3 v1)) { return; }
		position.x = Mathf.Round(v1.x);
		position.z = Mathf.Round(v1.z);
	}
	/// <summary> 按下 </summary>
	public virtual void CreateDown() {
		CreateComplete();
		// 添加回撤记录
		// UndoCommandCreate undo = new UndoCommandCreate(this);
		// UndoSystem.I.AddCommand(undo);
		// 完成创建
		PlaceHandleCreate.I.CreateComplete();
	}
	/// <summary> 抬起 </summary>
	public virtual void CreateUp() { }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

// public class KPathFind : IKinesis {

// 	/// <summary> 基础角色 </summary>
// 	public readonly MCharacter character;

// 	/// <summary> 移动速度 </summary>
// 	public float moveSpeed = 2;
// 	/// <summary> 加速度 </summary>
// 	public float acceleration = 15;
// 	/// <summary> 世界坐标 </summary>
// 	public Vector3 worldPosition;
// 	/// <summary> 初始偏移 </summary>
// 	public Vector3 offset;
// 	/// <summary> 初始位置 </summary>
// 	public Vector3 position;
// 	/// <summary> 初始角度 </summary>
// 	public Vector3 eulerAngles;

// 	private Vector3 targetPosition;// 目标位置
// 	private Queue<Vector3> vectorPath = new Queue<Vector3>();// 路径点队列

// 	/// <summary> 动画器 </summary>
// 	public Animator animator => character.animator;
// 	/// <summary> 运动器 </summary>
// 	public Movement movement => character.movement;

// 	public KPathFind(MCharacter character, Vector3 worldPosition, Vector3 offset) {
// 		this.character = character;
// 		this.worldPosition = worldPosition;
// 		this.offset = offset;
// 	}

// 	public void Settings(float moveSpeed, float acceleration) {
// 		this.moveSpeed = moveSpeed;
// 		this.acceleration = acceleration;
// 	}
// 	public void Settings(Vector3 position, Vector3 eulerAngles) {
// 		this.position = position;
// 		this.eulerAngles = eulerAngles;
// 	}

// 	public override bool Transition(IKinesis kinesis) {
// 		return false;
// 	}
// 	public override void StartKinesis() {
// 		movement.Settings(position + offset, eulerAngles);
// 		if (!ManagerMap.FindPath(position, worldPosition, out List<Vector3> pathFind)) { return; }
// 		vectorPath = new Queue<Vector3>();
// 		pathFind.ForEach(obj => vectorPath.Enqueue(obj + offset));
// 		SettingsTargetPosition();
// 	}
// 	public override void UpdateKinesis() {
// 		// 更新动画器
// 		animator.SetFloat("MoveSpeed", movement.Speed);
// 		// 移动
// 		float distance = Vector3.Distance(movement.Position, targetPosition);
// 		if (distance > 0.05f) { return; }
// 		if (vectorPath.Count == 0) {
// 			movement.Move(Vector2.zero, moveSpeed, acceleration, true);
// 			character.Transition(new KIdle());
// 		}
// 		else { SettingsTargetPosition(); }
// 	}
// 	public override void FinishKinesis() {
// 		// throw new System.NotImplementedException();
// 	}
// 	public override void AnimationExit() {
// 		// throw new System.NotImplementedException();
// 	}
// 	private void SettingsTargetPosition() {
// 		targetPosition = vectorPath.Dequeue();
// 		Vector3 direction = (targetPosition - movement.Position).normalized;
// 		Vector2 moveDirection = new Vector2(direction.x, direction.z);
// 		movement.Move(moveDirection, moveSpeed, acceleration, true);
// 	}
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterComponentMove : MonsterComponent {
    private float targetRotation;
    private float rotationVelocity;
    private Vector3 targetPosition;

    private PrefabMonster prefabMonster;
    private Queue<Vector3> vectorPath = new Queue<Vector3>();

    /// <summary> 动画器 </summary>
    public Animator animator => prefabMonster.animator;
    /// <summary> 怪物数据 </summary>
    public DataMonster Monster => prefabMonster.Value;
    /// <summary> 移动速度 </summary>
    public float Speed => Time.deltaTime * Monster.Speed * ModuleCore.HandleGameState.Current.PlaySpeed;

    /// <summary> 格子地图 DataGridMap 数据处理器 </summary>
    public ModuleHandle<DataGridMap> HandleGridMap => ModuleCore.HandleGridMap;

    public override void Initialize(PrefabMonster prefabMonster) {
        this.prefabMonster = prefabMonster;
        HandleGridMap_OnChange(HandleGridMap.Current);
        transform.position = Monster.position;
        Vector3 moveDirection = (targetPosition - Monster.position).normalized;
        transform.forward = moveDirection;
    }

    private void Awake() {
        HandleGridMap.OnChange += HandleGridMap_OnChange;
    }
    private void OnDestroy() {
        HandleGridMap.OnChange -= HandleGridMap_OnChange;
    }
    private void Update() {
        Monster.isDestination = Monster.position == targetPosition && vectorPath.Count == 0;
        if (Monster.isDestination) { return; }
        Vector3 moveDirection = (targetPosition - Monster.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * 10);
        //移动
        float distance = Vector3.Distance(Monster.position, targetPosition);
        Vector3 direction = (Monster.position - targetPosition).normalized;
        Vector3 position = Monster.position - direction * Speed;
        float difference = Vector3.Distance(position, targetPosition);
        if (difference > distance) { position = targetPosition; }
        Monster.position = transform.position = position;
        //切换下一个点
        if (transform.position != targetPosition || vectorPath.Count <= 0) { return; }
        targetPosition = vectorPath.Dequeue();
    }

    /// <summary> 地图改变重新寻路 </summary>
    private void HandleGridMap_OnChange(DataGridMap obj) {
        Vector3 sPosition = Monster.position;
        Vector3 ePosition = Monster.target.position;
        DataGridMapPathFind pathFind = new DataGridMapPathFind(obj, sPosition, ePosition);
        ModuleCore.ExecutePathFind.Execute(pathFind);
        if (!pathFind.isValid) { return; }
        //起点矫正
        if (pathFind.vectorPath.Count >= 2) {
            Vector3 position1 = pathFind.vectorPath[0];
            Vector3 position2 = pathFind.vectorPath[1];
            float distance2 = Vector3.Distance(position2, Monster.position);
            float distance1 = Vector3.Distance(position1, Monster.position) + distance2;
            if (distance1 > distance2) { pathFind.vectorPath.Remove(position1); }
        }
        //转换队列
        vectorPath = new Queue<Vector3>();
        pathFind.vectorPath.ForEach(obj => vectorPath.Enqueue(obj + Monster.offset));
        targetPosition = vectorPath.Dequeue();
        animator.SetBool("Move", true);
    }
}

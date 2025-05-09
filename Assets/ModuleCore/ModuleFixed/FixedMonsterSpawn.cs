using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物生产器
/// </summary>
public class FixedMonsterSpawn : ModuleFixed {
    /// <summary> 规则索引 </summary>
    public int index;
    /// <summary> 怪物路径 </summary>
    public LineRenderer monsterPath;
    /// <summary> 追击目标 </summary>
    public Transform target;
    /// <summary> 怪物生产规则 </summary>
    private MonsterSpawnRule spawnRule;
    /// <summary> 当前生产 </summary>
    [HideInInspector] public DataMonsterSpawn monsterSpawn;
    /// <summary> 生产倒计时预制件 </summary>
    [HideInInspector] public ModulePrefab<FixedMonsterSpawn> visual;

    /// <summary> 是否有效生产 </summary>
    public bool isValid => monsterSpawn != null && IsValid();
    /// <summary> 播放速度 </summary>
    public float PlaySpeed => Time.deltaTime * HandleGameState.Current.PlaySpeed;
    /// <summary> 格子地图  </summary>
    public DataGridMap GridMap => HandleGridMap.Current;

    /// <summary> 怪物 资产 </summary>
    public ModuleAssets<DataMonster> AssetsMonster => ModuleCore.AssetsMonster;
    /// <summary> 游戏状态 DataGameState 数据处理器 </summary>
    public ModuleHandle<DataGameState> HandleGameState => ModuleCore.HandleGameState;
    /// <summary> 怪物生产管理器 资产 </summary>
    public ModuleAssets<FixedMonsterSpawn> AssetsMonsterSpawn => ModuleCore.AssetsMonsterSpawn;
    /// <summary> 格子地图 DataGridMap 数据处理器 </summary>
    public ModuleHandle<DataGridMap> HandleGridMap => ModuleCore.HandleGridMap;
    /// <summary> 怪物生产 可视化内容生成模块 </summary>
    public ModuleVisual<FixedMonsterSpawn> VisualMonsterSpawn => ModuleCore.VisualMonsterSpawn;
    /// <summary> 路径查询 执行模块 </summary>
    public ModuleExecute<DataGridMapPathFind> ExecutePathFind => ModuleCore.ExecutePathFind;

    private void Start() {
        AssetsMonsterSpawn.Add(this);
        VisualMonsterSpawn.UpdateVisual(this);
        HandleGridMap.OnChange += HandleGridMap_OnChange;
        HandleGridMap_OnChange(GridMap);
        spawnRule = HandleGameState.Current.Grade.To(index);
    }
    private void Update() {
        if (monsterSpawn == null) { return; }
        if (monsterSpawn.spawnTime >= monsterSpawn.maxSpawnTime) { return; }
        monsterSpawn.spawnTime += PlaySpeed;
        monsterSpawn.spawnQueues.ForEach(UpdateSpawnQueue);
        visual.UpdateVisual(this);
    }
    private void OnDestroy() {
        AssetsMonsterSpawn.Remove(this);
        VisualMonsterSpawn.ReleaseVisual(this);
        if (HandleGridMap == null) { return; }
        HandleGridMap.OnChange -= HandleGridMap_OnChange;
    }

    #region 操作
    /// <summary> 更新地图时 </summary>
    private void HandleGridMap_OnChange(DataGridMap obj) {
        Vector3 sPosition = transform.position;
        Vector3 ePosition = target.position;
        DataGridMapPathFind pathFind = new DataGridMapPathFind(obj, sPosition, ePosition);
        ExecutePathFind.Execute(pathFind);
        if (!pathFind.isValid) { return; }
        List<Vector3> vectorPath = new List<Vector3>();
        pathFind.vectorPath.ForEach(obj => vectorPath.Add(obj + new Vector3(0, 0.1f, 0)));
        monsterPath.positionCount = vectorPath.Count;
        monsterPath.SetPositions(vectorPath.ToArray());
    }
    /// <summary> 更新生成等级 </summary>
    public void UpdateLevel(int level) => monsterSpawn = spawnRule.To(level);
    /// <summary> 是否通行 </summary>
    public bool Pass() {
        Vector3 sPosition = transform.position;
        Vector3 ePosition = target.position;
        DataGridMapPathFind pathFind = new DataGridMapPathFind(GridMap, sPosition, ePosition);
        ExecutePathFind.Execute(pathFind);
        return pathFind.isValid;
    }
    #endregion

    #region 生产
    /// <summary> 是否在生产怪物 </summary>
    private bool IsValid() {
        return monsterSpawn.spawnTime < monsterSpawn.maxSpawnTime;
    }
    /// <summary> 更新生产队列 生产一个怪物 </summary>
    private void UpdateSpawnQueue(DataMonsterSpawnQueue spawnQueue) {
        if (spawnQueue.quantity <= 0) { return; }
        if (spawnQueue.startTime > monsterSpawn.spawnTime) { return; }
        if (spawnQueue.spawnTime > 0) { spawnQueue.spawnTime -= PlaySpeed; return; }
        spawnQueue.spawnTime = spawnQueue.interval;
        spawnQueue.quantity--;

        DataMonster monster = spawnQueue.To();
        monster.target = target;
        monster.offset = RandomOffset();
        monster.position = transform.position + monster.offset;
        AssetsMonster.Add(monster);
    }
    /// <summary> 随机生成偏移值 </summary>
    private Vector3 RandomOffset() {
        float x = Random.Range(-0.3f, 0.3f);
        float z = Random.Range(-0.3f, 0.3f);
        return new Vector3(x, 0, z);
    }
    #endregion

}

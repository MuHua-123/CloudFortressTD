using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedGameState : ModuleFixed {
    public ConstLevel testLevel;
    public List<ConstCards> cardPool;
    public List<ConstTurret> buildList;
    public List<ConstTurret> turretPresets;

    /// <summary> 卡池 </summary>
    public ModuleAssets<ConstCards> CardPool => ModuleCore.CardPool;
    /// <summary> 炮塔预设库 </summary>
    public ModuleAssets<ConstTurret> TurretLibrary => ModuleCore.TurretLibrary;
    /// <summary> 炮塔建造列表 </summary>
    public ModuleAssets<ConstTurret> TurretBuildList => ModuleCore.TurretBuildList;
    /// <summary> 怪物生产管理器 资产 </summary>
    public ModuleAssets<FixedMonsterSpawn> AssetsMonsterSpawn => ModuleCore.AssetsMonsterSpawn;
    /// <summary> 游戏状态 DataGameState 数据处理器 </summary>
    public ModuleHandle<DataGameState> HandleGameState => ModuleCore.HandleGameState;
    /// <summary> 游戏页面 DataGamePage 数据处理器 </summary>
    public ModuleHandle<DataGamePage> HandleGamePage => ModuleCore.HandleGamePage;

    private void Awake() {
        DataGameState gameState = Initialize();
        HandleGameState.Change(gameState);

        CardPool.Datas.Clear();
        CardPool.AddRange(cardPool);

        TurretBuildList.Datas.Clear();
        TurretBuildList.AddRange(buildList);

        TurretLibrary.AddRange(turretPresets);
        TurretLibrary.ForEach(obj => obj.Count = 0);
    }
    protected void Update() {
        if (ValidMonsterSpawn()) { return; }

        HandleGameState.Current.Level++;
        AssetsMonsterSpawn.ForEach(obj => obj.UpdateLevel(HandleGameState.Current.Level));
        SingleStandardMode.I.RandomDrawCards();
    }

    /// <summary> 初始化游戏状态 </summary>
    private DataGameState Initialize() {
        DataGameState gameState = new DataGameState();
        gameState.MaxLevel = 30;
        gameState.Level = 0;
        gameState.Health = 10;
        gameState.GoldCoin = 2000;
        gameState.Grade = testLevel.grades[0];
        return gameState;
    }
    /// <summary> 判断是否有效生产 </summary>
    private bool ValidMonsterSpawn() {
        List<FixedMonsterSpawn> spawnList = AssetsMonsterSpawn.Datas;
        for (int i = 0; i < spawnList.Count; i++) {
            if (spawnList[i].isValid) { return true; }
        }
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 核心模块，实现业务逻辑
/// </summary>
public class ModuleCore : Module<ModuleCore> {

    #region 资产模块
    /// <summary> 关卡 资产 </summary>
    public ModuleAssets<ConstLevel> AssetsLevel = new ModuleAssets<ConstLevel>();

    /// <summary> 卡池 </summary>
    public ModuleAssets<ConstCards> CardPool = new ModuleAssets<ConstCards>();

    /// <summary> 怪物 资产 </summary>
    public ModuleAssets<DataMonster> AssetsMonster = new AssetsMonster();
    /// <summary> 怪物生产管理器 资产 </summary>
    public ModuleAssets<FixedMonsterSpawn> AssetsMonsterSpawn = new ModuleAssets<FixedMonsterSpawn>();

    /// <summary> 炮塔 资产 </summary>
    public ModuleAssets<DataTurret> AssetsTurret = new AssetsTurret();
    /// <summary> 炮塔预设库 </summary>
    public ModuleAssets<ConstTurret> TurretLibrary = new ModuleAssets<ConstTurret>();
    /// <summary> 炮塔建造列表 </summary>
    public ModuleAssets<ConstTurret> TurretBuildList = new ModuleAssets<ConstTurret>();
    #endregion

    #region 数据模块
    /// <summary> 游戏页面 DataGamePage 数据处理器 </summary>
    public ModuleHandle<DataGamePage> HandleGamePage = new ModuleHandle<DataGamePage>();
    /// <summary> 游戏状态 DataGameState 数据处理器 </summary>
    public ModuleHandle<DataGameState> HandleGameState = new ModuleHandle<DataGameState>();
    /// <summary> 格子地图 DataGridMap 数据处理器 </summary>
    public ModuleHandle<DataGridMap> HandleGridMap = new ModuleHandle<DataGridMap>();
    /// <summary> 炮塔建造 ConstTurret 数据处理器 </summary>
    public ModuleHandle<ConstTurret> HandleTurretBuild = new ModuleHandle<ConstTurret>();
    /// <summary> 炮塔 DataTurret 数据处理器 </summary>
    public ModuleHandle<DataTurret> HandleTurret = new ModuleHandle<DataTurret>();
    #endregion

    #region 相机模块
    /// <summary> 当前相机模块 </summary>
    public OldModuleCamera CurrentCamera;
    #endregion

    #region 页面模块
    /// <summary> 不会被销毁的全局唯一页面模块 (UIDocument) </summary>
    public ModuleDocument GlobalPage;
    /// <summary> 当前的主要页面模块 (UIDocument) </summary>
    public ModuleDocument CurrentPage;
    #endregion

    #region 执行模块
    /// <summary> 弹出文本 执行模块 </summary>
    public ModuleExecute<DataPopupText> ExecutePopupText;
    /// <summary> 连接墙 执行模块 </summary>
    public ModuleExecute<DataGridMapUnit> ExecuteConnectWall;
    /// <summary> 震动相机 执行模块 </summary>
    public ModuleExecute<DataShakeCamera> ExecuteShakeCamera;
    /// <summary> 临时道具 执行模块 </summary>
    public ModuleExecute<DataTemporaryProps> ExecuteTemporaryProps;
    /// <summary> 伤害计算 执行模块 </summary>
    public ModuleExecute<DataDamage> ExecuteDamage = new ExecuteDamage();
    /// <summary> 路径查询 执行模块 </summary>
    public ModuleExecute<DataGridMapPathFind> ExecutePathFind = new ExecuteGridMapPathFind();
    #endregion

    #region 可视模块
    /// <summary> 炮塔 可视化内容生成模块 </summary>
    public ModuleVisualOld<DataTurret> VisualTurret;
    /// <summary> 炮弹 DataBullet 可视化内容生成模块 </summary>
    public ModuleVisualOld<DataBullet> VisualBullet;
    /// <summary> 怪物 可视化内容生成模块 </summary>
    public ModuleVisualOld<DataMonster> VisualMonster;
    /// <summary> 怪物生产 可视化内容生成模块 </summary>
    public ModuleVisualOld<FixedMonsterSpawn> VisualMonsterSpawn;
    /// <summary> 生命值 可视化内容生成模块 </summary>
    public ModuleVisualOld<DataMonster> VisualHitPoints;
    #endregion
}
/// <summary>
/// 模块基类
/// </summary>
public class Module<ModuleCore> where ModuleCore : Module<ModuleCore>, new() {
    /// <summary> 模块单例 </summary>
    public static ModuleCore I => Instantiate();

    private static ModuleCore core;
    private static ModuleCore Instantiate() => core == null ? core = new ModuleCore() : core;
}
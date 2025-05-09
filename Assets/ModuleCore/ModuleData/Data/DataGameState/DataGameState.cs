using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏状态数据
/// </summary>
public class DataGameState {
    /// <summary> 播放速度 </summary>
    public float PlaySpeed = 0;
    /// <summary> 最大炮塔建筑列表计数 </summary>
    public int MaxTurretBuildListCount = 6;

    #region 关卡数值
    /// <summary> 最大等级 </summary>
    private int maxLevel;
    /// <summary> 当前等级 </summary>
    private int level;
    /// <summary> 当前生命值 </summary>
    private int health;
    /// <summary> 当前金币 </summary>
    private int goldCoin;
    /// <summary> 关卡难度 </summary>
    private ConstLevelGrade grade;

    /// <summary> 数值更新 </summary>
    public event Action OnUpdateValue;
    /// <summary> 最大等级 </summary>
    public int MaxLevel {
        get { return maxLevel; }
        set { maxLevel = value; OnUpdateValue?.Invoke(); }
    }
    /// <summary> 当前等级 </summary>
    public int Level {
        get { return level; }
        set { level = value; OnUpdateValue?.Invoke(); }
    }
    /// <summary> 当前生命值 </summary>
    public int Health {
        get { return health; }
        set { health = value; OnUpdateValue?.Invoke(); }
    }
    /// <summary> 当前金币 </summary>
    public int GoldCoin {
        get { return goldCoin; }
        set { goldCoin = value; OnUpdateValue?.Invoke(); }
    }
    /// <summary> 关卡难度 </summary>
    public ConstLevelGrade Grade {
        get { return grade; }
        set { grade = value; OnUpdateValue?.Invoke(); }
    }
    #endregion

}

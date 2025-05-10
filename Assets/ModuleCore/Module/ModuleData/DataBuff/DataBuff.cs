using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// buff数据
/// </summary>
public abstract class DataBuff {
    /// <summary> 来源 </summary>
    public object origin;
    /// <summary> 持续时间 </summary>
    public float time;
    /// <summary> 统计数据 </summary>
    public abstract void To(DataBuffStats stats);
    /// <summary> 比较数据 </summary>
    public abstract bool Compare(DataBuff buff);
}
/// <summary>
/// 移动速度buff
/// </summary>
public class MoveSpeedBuff : DataBuff {
    /// <summary> 移动速度系数(0-1000) </summary>
    public int speedFactor;

    public override void To(DataBuffStats stats) {
        stats.speedFactor += speedFactor;
    }
    public override bool Compare(DataBuff buff) {
        MoveSpeedBuff speedBuff = (MoveSpeedBuff)buff;
        return speedBuff != null && speedBuff.origin == origin;
    }
}

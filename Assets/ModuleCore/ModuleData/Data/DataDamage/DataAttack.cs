using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 攻击数据
/// </summary>
public class DataAttack {
    /// <summary> 基础数值 </summary>
    public int value;
    /// <summary> 生命系数 </summary>
    public int hpFactor;
    /// <summary> 护甲系数 </summary>
    public int acFactor;
    /// <summary> 护盾系数 </summary>
    public int esFactor;
    /// <summary> 命中位置 </summary>
    public Vector3 hitPosition;
    /// <summary> buff列表 </summary>
    public List<DataBuff> buffs = new List<DataBuff>();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 防御数据
/// </summary>
public class DataDefense {
    /// <summary> 生命值 </summary>
    public int hp;
    /// <summary> 护甲值 </summary>
    public int ac;
    /// <summary> 能量值 </summary>
    public int es;
    /// <summary> buff列表 </summary>
    public List<DataBuff> buffs = new List<DataBuff>();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// buff统计数据
/// </summary>
public class DataBuffStats {
    /// <summary> 移动速度系数 </summary>
    public int speedFactor;
}
public static class DataBuffTool {
    /// <summary> 更新buff </summary>
    public static DataBuffStats Update(List<DataBuff> buffs) {
        DataBuffStats stats = new DataBuffStats();
        for (int i = 0; i < buffs.Count; i++) {
            DataBuff buff = buffs[i];
            buff.time -= Time.deltaTime;
            if (buff.time <= 0) { buffs.Remove(buff); }
            buff.To(stats);
        }
        return stats;
    }
    /// <summary> 添加buff </summary>
    public static void Add(List<DataBuff> buffs, DataBuff buff) {
        for (int i = 0; i < buffs.Count; i++) {
            if (buff.Compare(buffs[i])) { buffs[i] = buff; return; }
        }
        buffs.Add(buff);
    }
}
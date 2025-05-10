using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConstCards", menuName = "数据模块/卡牌/卡牌数据01")]
public class ConstCards01 : ConstCards {
    public ConstTurret turret;
    public List<ConstCards> adds;

    public override string Describe => $"* 解锁 {turret.name}";

    public override void Select() {
        ModuleCore.CardPool.Remove(this);
        //小于计数直接添加
        int count = ModuleCore.HandleGameState.Current.MaxTurretBuildListCount;
        ModuleAssets<ConstTurret> buildList = ModuleCore.TurretBuildList;
        if (buildList.Count < count) { buildList.Add(turret); return; }
        //大于计数进行替换
        SingleStandardMode.I.ReplaceTurretList(turret);
    }
}

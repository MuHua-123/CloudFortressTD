using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MuHua;

public class SingleStandardMode : ModuleSingle<SingleStandardMode> {
	public UIDrawCardsPage drawCards;
	public UIReplaceTurretPage replaceTurret;

	protected override void Awake() => Replace();

	/// <summary> 随机抽牌 </summary>
	public void RandomDrawCards() {
		ModuleCore.I.HandleGamePage.Change(DataGamePage.DrawCards);
		drawCards.RandomDrawCards();
	}
	/// <summary> 替换炮塔列表 </summary>
	public void ReplaceTurretList(ConstTurret turret) {
		ModuleCore.I.HandleGamePage.Change(DataGamePage.ReplaceTurret);
		replaceTurret.ReplaceTurretList(turret);
	}
}


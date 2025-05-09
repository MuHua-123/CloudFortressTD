using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using MuHua;

/// <summary>
/// 炮塔操作面板
/// </summary>
public class FixedTurretPanel : ModuleFixed {
	public TMP_Text upgradeT;//升级
	public TMP_Text aimTypeT;//瞄准
	public TMP_Text recycleT;//回收
	private DataTurret turret;

	private Transform Follower => turret.visual.transform;
	/// <summary> 当前游戏状态 </summary>
	public DataGameState GameState => HandleGameState.Current;

	/// <summary> 炮塔 资产 </summary>
	public ModuleAssets<DataTurret> AssetsTurret => ModuleCore.AssetsTurret;
	/// <summary> 游戏状态 DataGameState 数据处理器 </summary>
	public ModuleHandle<DataGameState> HandleGameState => ModuleCore.HandleGameState;
	/// <summary> 炮塔 DataTurret 数据处理器 </summary>
	public ModuleHandle<DataTurret> HandleTurret => ModuleCore.HandleTurret;
	/// <summary> 炮塔 可视化内容生成模块 </summary>
	public ModuleVisual<DataTurret> VisualTurret => ModuleCore.VisualTurret;
	/// <summary> 连接墙 执行模块 </summary>
	public ModuleExecute<DataGridMapUnit> ExecuteConnectWall => ModuleCore.ExecuteConnectWall;

	private void Awake() {
		HandleTurret.OnChange += HandleTurret_OnChange;
	}
	private void OnDestroy() {
		HandleTurret.OnChange -= HandleTurret_OnChange;
	}
	private void Update() {
		if (turret == null || turret.visual == null) { return; }
		transform.position = Follower.position;
		transform.LookAt(transform.position + Camera.main.transform.forward);
		Vector3 direction = (Camera.main.transform.position - transform.position).normalized;
		transform.position = transform.position + new Vector3(0, 0.1f, 0) + direction * 5;
	}

	private void HandleTurret_OnChange(DataTurret turret) {
		this.turret = turret;
		foreach (Transform item in transform) {
			item.gameObject.SetActive(turret != null);
		}
		if (turret == null) { return; }
		if (turret.IsCanUpgraded) { upgradeT.text = $"升级{turret.UpgradeValue}￥"; }
		else { upgradeT.text = $"Max Level"; }
		aimTypeT.text = $"攻击：最近";
		recycleT.text = $"出售{turret.buildValue}￥";
	}

	/// <summary> 升级炮塔 </summary>
	public async void Upgrade() {
		//是否能升级
		if (!turret.IsCanUpgraded) { return; }
		//判断金币是否够建造
		if (GameState.GoldCoin < turret.UpgradeValue) { return; }
		turret.buildValue += turret.UpgradeValue;
		GameState.GoldCoin -= turret.UpgradeValue;
		turret.grade++;

		DataTurret temp = turret;
		VisualTurret.ReleaseVisual(temp);
		HandleTurret.Change(null);
		await Task.Delay(500);
		VisualTurret.UpdateVisual(temp);
	}
	/// <summary> 攻击优先级 </summary>
	public void AimType() {

	}
	/// <summary> 回收炮塔 </summary>
	public void Recycle() {
		GameState.GoldCoin += turret.buildValue;
		turret.presets.BuildCount(-1);
		AssetsTurret.Remove(turret);
		HandleTurret.Change(null);
	}
}

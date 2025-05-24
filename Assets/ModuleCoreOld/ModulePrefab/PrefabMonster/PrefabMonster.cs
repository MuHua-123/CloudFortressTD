using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物预制件
/// </summary>
public class PrefabMonster : ModulePrefab<DataMonster> {
    /// <summary> 怪物身体 </summary>
    public Transform body;
    /// <summary> 死亡模型 </summary>
    public Transform die;
    /// <summary> 血条的高度 </summary>
    public Vector3 height;

    /// <summary> 动画器 </summary>
    public Animator animator => GetComponent<Animator>();
    /// <summary> 命中组件 </summary>
    public MonsterComponent hit => GetComponent<MonsterComponentHit>();
    /// <summary> 移动组件 </summary>
    public MonsterComponent move => GetComponent<MonsterComponentMove>();

    /// <summary> 怪物 资产 </summary>
    public ModuleAssets<DataMonster> AssetsMonster => ModuleCore.AssetsMonster;
    /// <summary> 临时道具 执行模块 </summary>
    public ModuleExecute<DataTemporaryProps> ExecuteTemporaryProps => ModuleCore.ExecuteTemporaryProps;
    /// <summary> 伤害计算 执行模块 </summary>
    public ModuleExecute<DataDamage> ExecuteDamage => ModuleCore.ExecuteDamage;

    private void Awake() {
        ModuleCore.HandleGameState.OnChange += HandleGameState_OnChange;
    }
    private void OnDestroy() {
        ModuleCore.HandleGameState.OnChange -= HandleGameState_OnChange;
    }
    private void Update() {
        //更新buff
        Value.stats = DataBuffTool.Update(Value.buffs);
        //到达目的地而死亡
        if (!Value.isDestination || !Value.isArriveFinal) { return; }
        AssetsMonster.Remove(Value);
        ModuleCore.HandleGameState.Current.Health--;
    }

    public override void UpdateVisual(DataMonster monster) {
        base.UpdateVisual(monster);
        monster.height = height;
        hit.Initialize(this);
        move.Initialize(this);
        HandleGameState_OnChange(ModuleCore.HandleGameState.Current);
    }

    /// <summary> 设置动画速度 </summary>
    private void HandleGameState_OnChange(DataGameState obj) {
        animator.SetFloat("PlaySpeed", obj.PlaySpeed);
    }
    public void Damage(DataAttack attack) {
        if (Value.hp.x <= 0) { return; }
        //伤害结算
        DataDamage damage = Value.To(attack);
        ExecuteDamage.Execute(damage);
        Value.To(damage.defense);
        //受击效果
        hit.UpdateVisual();
        //收到伤害而死亡
        if (Value.hp.x > 0) { return; }
        AssetsMonster.Remove(Value);
        ModuleCore.HandleGameState.Current.GoldCoin += Value.cost;
        //创建死亡效果
        DataTemporaryProps props = new DataTemporaryProps();
        props.prefab = die;
        props.position = body.position;
        ExecuteTemporaryProps.Execute(props);
    }
}

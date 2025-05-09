using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 伤害计算 执行模块
/// </summary>
public class ExecuteDamage : ModuleExecute<DataDamage> {
    public void Execute(DataDamage damage) {
        int attackValue = damage.attack.value;
        Vector3 hitPosition = damage.attack.hitPosition;
        //附加buff
        UpdateBuffs(damage.attack, damage.defense);
        //护盾
        int esValue = damage.defense.es;
        int esFactor = damage.attack.esFactor;
        bool esFormula = Formula(ref attackValue, ref esValue, esFactor, out int esElement);
        damage.defense.es = esValue;
        if (esElement > 0) { PopupText(esElement, hitPosition); }
        if (esFormula) { return; }
        //护甲
        int acValue = damage.defense.ac;
        int acFactor = damage.attack.acFactor;
        bool acFormula = Formula(ref attackValue, ref acValue, acFactor, out int acElement);
        damage.defense.ac = acValue;
        if (acElement > 0) { PopupText(acElement, hitPosition); }
        if (acFormula) { return; }
        //生命值
        int hpValue = damage.defense.hp;
        int hpFactor = damage.attack.hpFactor;
        bool hpFormula = Formula(ref attackValue, ref hpValue, hpFactor, out int hpElement);
        damage.defense.hp = hpValue;
        PopupText(hpElement, hitPosition);
    }
    /// <summary> 更新buff </summary>
    private void UpdateBuffs(DataAttack attack, DataDefense defense) {
        for (int i = 0; i < attack.buffs.Count; i++) {
            DataBuff buff = attack.buffs[i];
            DataBuffTool.Add(defense.buffs, buff);
        }
    }
    /// <summary> 伤害计算公式 </summary>
    private bool Formula(ref int attackValue, ref int value, int factor, out int element) {
        //值小于0退出
        if (value <= 0) { element = 0; return false; }
        //计算伤害系数
        element = Mathf.FloorToInt(attackValue * factor / 100f);
        //计算伤害
        value -= element;
        //如果大于等于0，则抵消伤害退出
        if (value >= 0) { return true; }
        //小于0差则是未抵消的伤害
        int differ = Mathf.Abs(value);
        //计算剩余伤害
        attackValue = Mathf.FloorToInt(attackValue * (differ / (float)element));
        //计算已造成的伤害
        element -= differ;
        return false;
    }
    /// <summary> 伤害弹出 </summary>
    private void PopupText(int damage, Vector3 position) {
        DataPopupText popupText = new DataPopupText();
        popupText.duration = 1;
        popupText.content = damage.ToString();
        popupText.position = position + RandomOffset();
        ModuleCore.I.ExecutePopupText.Execute(popupText);
    }
    /// <summary> 随机生成偏移值 </summary>
    private Vector3 RandomOffset() {
        float x = Random.Range(-0.2f, 0.2f);
        float z = Random.Range(-0.2f, 0.2f);
        return new Vector3(x, 0, z);
    }
}

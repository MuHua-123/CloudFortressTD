using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 卡牌库
/// </summary>
public class ConstCardLibrary : ScriptableObject {
    public List<ConstCards> initial;//初始使用的卡牌
    public List<ConstCards> cardPool;//当前卡池
    public List<ConstCards> allCards;//卡牌库
}

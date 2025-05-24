using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 抽卡页面
/// </summary>
public class UIDrawCardsPage : ModuleUIPageo {
    public VisualTreeAsset CardsTemplate;
    private List<UICardsItem> cardsItems = new List<UICardsItem>();

    public override VisualElement Element => document.Q<VisualElement>("DrawCards");
    public VisualElement BG => Element.Q<VisualElement>("BG");

    public void Awake() {
        ModuleCore.HandleGamePage.OnChange += HandleGamePage_OnChange;
    }
    private void OnDestroy() {
        ModuleCore.HandleGamePage.OnChange -= HandleGamePage_OnChange;
    }

    private void HandleGamePage_OnChange(DataGamePage obj) {
        BG.EnableInClassList("dc-bg-open", obj == DataGamePage.DrawCards);
    }

    /// <summary> 随机抽牌 </summary>
    public void RandomDrawCards() {
        List<ConstCards> constCards = ModuleCore.CardPool.RandomRange(3);
        if (constCards.Count <= 0) { ModuleCore.HandleGamePage.Change(DataGamePage.StandardMode); }
        CreateUICardsItem(constCards);
    }
    private void CreateUICardsItem(List<ConstCards> constCards) {
        BG.Clear();
        cardsItems.ForEach(obj => obj.Release());
        cardsItems = new List<UICardsItem>();
        constCards.ForEach(CreateUICardsItem);
    }
    private void CreateUICardsItem(ConstCards value) {
        VisualElement element = CardsTemplate.Instantiate();
        UICardsItem item = new UICardsItem(value, element);
        cardsItems.Add(item);
        BG.Add(item.element);
    }
}

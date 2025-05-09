using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MuHua;

public class UILevelPage : ModuleUIPage {
	public override VisualElement Element => root.Q<VisualElement>("LevelPage");
}

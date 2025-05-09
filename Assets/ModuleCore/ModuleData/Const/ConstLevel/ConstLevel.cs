using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 关卡数据
/// </summary>
[CreateAssetMenu(fileName = "ConstLevel", menuName = "数据模块/关卡数据")]
public class ConstLevel : ScriptableObject {
    /// <summary> 预览图 </summary>
    public Sprite icon;
    /// <summary> 难度列表 </summary>
    [HideInInspector] public List<ConstLevelGrade> grades;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 连接墙
/// </summary>
public class DataConnectWall {
    /// <summary> 连接方向 </summary>
    public ConnectWallType type;
    /// <summary> 墙体 </summary>
    public Transform wall;
}
/// <summary>
/// 连接墙方向
/// </summary>
public enum ConnectWallType {
    /// <summary> 上 </summary>
    above = 0,
    /// <summary> 下 </summary>
    below = 1,
    /// <summary> 左 </summary>
    lefts = 2,
    /// <summary> 右 </summary>
    right = 3,

    /// <summary> 左上 </summary>
    leftsAbove = 4,
    /// <summary> 左下 </summary>
    leftsBelow = 5,
    /// <summary> 右上 </summary>
    rightAbove = 6,
    /// <summary> 右下 </summary>
    rightBelow = 7,
}

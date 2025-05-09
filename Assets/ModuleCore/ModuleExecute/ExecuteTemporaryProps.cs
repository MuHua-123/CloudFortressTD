using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 临时道具
/// </summary>
public class DataTemporaryProps {
    /// <summary> 预制件 </summary>
    public Transform prefab;
    /// <summary> 生成位置 </summary>
    public Vector3 position;
}
/// <summary>
/// 临时道具 执行模块
/// </summary>
public class ExecuteTemporaryProps : ModuleFixed, ModuleExecute<DataTemporaryProps> {

    public void Awake() => ModuleCore.ExecuteTemporaryProps = this;

    public void Execute(DataTemporaryProps props) {
        Transform temp = Instantiate(props.prefab, transform);
        temp.position = props.position;
    }
}

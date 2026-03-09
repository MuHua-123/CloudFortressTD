using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 标准 - 怪物波次常量
/// </summary>
[CreateAssetMenu(fileName = "WaveStandardConst", menuName = "MuHua/怪物生产/标准")]
public class WaveStandardConst : MonsterWaveConst {
	/// <summary> 总波次 </summary>
	public List<WaveStandardUnit> units = new List<WaveStandardUnit>();

	public override MonsterWave To() => new WaveStandard(units);
}

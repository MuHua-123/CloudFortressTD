using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterSpawnRule : ScriptableObject {
    public abstract DataMonsterSpawn To(int level);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAsset", menuName = "Enemy Asset/Enemy Data", order = 2)]
public class EnemyData : ScriptableObject {
    public Movement movement;
    public SimpleAudioConfig audioConfig;
    public CombatData combat;
}

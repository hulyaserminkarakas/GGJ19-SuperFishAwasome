using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Combat Data", menuName = "Enemy Asset/Combat Data", order = 3)]
public class CombatData : ScriptableObject
{
    public int touchDamage = 10;
    public int hp = 100;
    public List<Attack> attackSet;
}

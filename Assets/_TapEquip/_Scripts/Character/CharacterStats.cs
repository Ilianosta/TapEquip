using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharStats", menuName = "TapEquip/CharacterStats", order = 0)]
public class CharacterStats : ScriptableObject
{
    public Stats stats;
    public AnimationCurve statsPerLevel;
}
[System.Serializable]
public class Stats
{
    public float life;
    public float attack;
    public float resistance;
    public float critRate;
    public float luck;
}

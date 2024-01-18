using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillStatSO", menuName = "TapEquip/SkillStatSO")]
public class SkillStatSO : ScriptableObject
{
    public float baseAmount;
    public float amountScale;
    public SkillEffect skillEffect;
    public SkillSpecialEffect[] skillSpecialEffect;

    // Enums
    public enum SkillEffect
    {
        Damage,
        Heal,
        Barrier
    }
    public enum SkillSpecialEffect
    {
        none
    }
}


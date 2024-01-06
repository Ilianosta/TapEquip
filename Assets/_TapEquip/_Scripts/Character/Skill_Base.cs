using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Skill_Base : MonoBehaviour
{
    [SerializeField] protected SkillStatSO skillSO;
    public abstract void SkillAnimation();
}

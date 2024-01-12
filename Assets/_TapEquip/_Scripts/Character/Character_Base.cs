using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character_Base : MonoBehaviour
{
    [SerializeField] protected CharacterStats statsSO;
    [SerializeField] protected SkillStatSO[] skills;
    [SerializeField] public SkillStatSO selectedSkill;

    protected Stats myStats;
    protected virtual void Awake()
    {
        // myStats = statsSO.stats;
        foreach (SkillStatSO skill in skills) skill.skillOwner = myStats;
    }
    protected virtual void Start()
    {
        GameManager.SpawnCharacters += (show) =>
        {
            if (show) CreateCharacter();
            else HideCharacter();
        };
        if (skills.Length > 0)
            ReceiveSkill(skills[0]);
    }
    public void TakeDamage(float amount)
    {
        // myStats.life -= amount;
        // if (myStats.life < 0) Die();
    }
    public void Heal(float amount)
    {
        // myStats.life += amount;
    }
    public void ApplyEquipmentStats()
    {
        // TODO: CREATE AN EQUIPMENT SYSTEM
    }
    public void ReceiveSkill(SkillStatSO skill)
    {
        // float amount = skill.GetScaledAmount(skill.skillOwner.attack);
        // Debug.Log("Skill without scaled" + skill.baseAmount);
        // Debug.Log("Skill with scaled: " + amount);
        // switch (skill.skillEffect)
        // {
        //     case SkillStatSO.SkillEffect.Damage:
        //         TakeDamage(amount);
        //         break;
        //     case SkillStatSO.SkillEffect.Heal:
        //         Heal(amount);
        //         break;
        //     case SkillStatSO.SkillEffect.Barrier:
        //         // TODO: BARRIER SYSTEM
        //         break;
        //     default:
        //         break;
        // }
    }
    public void UseSkill(GameObject target)
    {
        var validTarget = target.GetComponent<Character_Base>();
        if (validTarget == null) return;
        validTarget.ReceiveSkill(selectedSkill);
    }
    protected abstract void Die();
    protected abstract void CreateCharacter();
    protected abstract void HideCharacter();
}

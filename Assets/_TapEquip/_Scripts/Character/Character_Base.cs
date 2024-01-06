using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character_Base : MonoBehaviour
{
    [SerializeField] protected CharacterStats statsSO;
    [SerializeField] protected SkillStatSO[] skills;
    [SerializeField] protected SkillStatSO selectedSkill;

    protected Stats myStats;
    protected void Awake()
    {
        myStats = statsSO.stats;
    }
    protected virtual void Start()
    {
        GameManager.SpawnCharacters += (show) =>
        {
            if (show) CreateCharacter();
            else HideCharacter();
        };
    }
    public void TakeDamage(float amount)
    {
        myStats.life -= amount;
        if (myStats.life < 0) Die();
    }
    public void Heal(float amount)
    {
        myStats.life += amount;
    }
    public void ApplyEquipmentStats()
    {
        // TODO: CREATE AN EQUIPMENT SYSTEM
    }
    public void ReceiveSkill(SkillStatSO skill, Character_Base from)
    {
        float amount = skill.GetScaledAmount(from.myStats.attack);
        switch (skill.skillEffect)
        {
            case SkillStatSO.SkillEffect.Damage:
                TakeDamage(amount);
                break;
            case SkillStatSO.SkillEffect.Heal:
                Heal(amount);
                break;
            case SkillStatSO.SkillEffect.Barrier:
                // TODO: BARRIER SYSTEM
                break;
            default:
                break;
        }
    }
    public void UseSkill(GameObject target)
    {
        var validTarget = target.GetComponent<Character_Base>();
        if (validTarget == null) return;
        validTarget.ReceiveSkill(selectedSkill, this);
    }
    protected abstract void Die();
    protected abstract void CreateCharacter();
    protected abstract void HideCharacter();
}

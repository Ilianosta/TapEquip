using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character_Base : MonoBehaviour
{
    [SerializeField] protected CharacterStats statsSO;
    [SerializeField] protected SkillStatSO[] skills;
    [SerializeField] public SkillStatSO selectedSkill;

    [SerializeField] private List<Stat> stats = new List<Stat>();
    protected virtual void Awake()
    {
        stats = statsSO.stats;
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
        GetStat(StatsBase.life).amount -= amount;
    }
    public void Heal(float amount)
    {
        GetStat(StatsBase.life).amount += amount;
    }
    public void ApplyEquipmentStats()
    {
        // TODO: CREATE AN EQUIPMENT SYSTEM
    }
    public void ReceiveSkill(SkillStatSO skill)
    {
        float amount = skill.baseAmount;
        Debug.Log("Skill without scaled" + skill.baseAmount);
        // Debug.Log("Skill with scaled: " + amount);
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
    public void UseSkill(Character_Base target)
    {
        target.ReceiveSkill(selectedSkill);
    }
    public Stat GetStat(StatsBase statName)
    {
        Stat stat = stats.Find((stat) => stat.statBase.Equals(statName));
        return stat;
    }
    protected abstract void Die();
    protected abstract void CreateCharacter();
    protected abstract void HideCharacter();
}

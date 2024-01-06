using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character_Base : MonoBehaviour
{
    [SerializeField] protected CharacterStats statsSO;
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
    public void Atack(GameObject target)
    {
        var validTarget = target.GetComponent<Character_Base>();
        if (validTarget == null) return;
        validTarget.TakeDamage(myStats.attack);
    }
    protected abstract void Die();
    protected abstract void CreateCharacter();
    protected abstract void HideCharacter();
}

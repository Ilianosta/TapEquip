using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharStats", menuName = "TapEquip/CharacterStats", order = 0)]
public class CharacterStats : ScriptableObject
{
    public List<Stat> stats = new List<Stat>();

    [ContextMenu("SetDefaultStats")]
    private void SetDefaultStats()
    {
        stats = new List<Stat>();
        stats.Clear();
        StatsBase[] statsBases = System.Enum.GetValues(typeof(StatsBase)) as StatsBase[];
        foreach (StatsBase statBase in statsBases)
        {
            stats.Add(new Stat(statBase));
        }
    }

    public Stat GetStat(StatsBase statName)
    {
        foreach (Stat stat in stats)
        {
            if (stat.statBase == statName) return stat;
        }
        return null;
    }
}
[System.Serializable]
public class Stat
{
    public StatsBase statBase;
    public float amount;
    public AnimationCurve amountPerLevel;
    public Stat(StatsBase statBase)
    {

        this.statBase = statBase;
        AnimationCurve curve = new AnimationCurve();
        curve.AddKey(0, 1);
        curve.AddKey(1, 10);
        amountPerLevel = curve;
        this.amount = amountPerLevel.Evaluate(0);
    }

    public void UpdateAmountPerLevel(int level)
    {
        amount = amountPerLevel.Evaluate(level);
    }
}
public enum StatsBase
{
    life,
    attack,
    resistance,
    critRate,
    luck
}
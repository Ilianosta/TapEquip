using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;
    [SerializeField] private int initialMoneyAmounut;
    private Currency actualCurrency;
    private Currency actualPremiumCurrency;
    [ReadOnly(true)] public Currency ActualCurrency => actualCurrency;
    [ReadOnly(true)] public Currency ActualPremiumCurrency => actualPremiumCurrency;

    public void UpdateCurrencyAmount(int amount) => actualCurrency.amount += amount;
    public void UpdatePremiumCurrencyAmount(int amount) => actualPremiumCurrency.amount += amount;

    private void Awake()
    {
        if (CurrencyManager.instance) Destroy(this);
        else CurrencyManager.instance = this;
    }

    public enum CurrencyType
    {
        basic,
        premium,
        experience
    }
    [System.Serializable]
    public class Currency
    {
        public CurrencyType type;
        public int amount;
    }
}

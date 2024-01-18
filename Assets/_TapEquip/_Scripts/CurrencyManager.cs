using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;
    [SerializeField] private List<Currency> currencies = new List<Currency>();
    private void Awake()
    {
        if (CurrencyManager.instance) Destroy(this);
        else CurrencyManager.instance = this;

        // Create base money
        foreach (CurrencyType currencyType in System.Enum.GetValues(typeof(CurrencyType)))
        {
            Currency newCurrency = new Currency(currencyType, 0);
            currencies.Add(newCurrency);
        }
    }
    public void ModifyCurrency(CurrencyType type, int amount)
    {
        foreach (Currency currency in currencies)
        {
            if (currency.type == type)
            {
                currency.amount += amount;
                currency.Save();
                break;
            }
        }
    }
    [ReadOnly(true)]
    public Currency GetCurrency(CurrencyType type)
    {
        foreach (Currency currency in currencies)
        {
            if (currency.type == type) return currency;
        }
        return null;
    }
    public bool HasEnoughCurrency(CurrencyType type, int amount)
    {
        if (GetCurrency(type).amount >= amount) return true;
        else return false;
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
        public Currency(CurrencyType type, int amount)
        {
            this.type = type;
            this.amount = amount;
            CreateOrLoadCurrencyRegister(amount);
        }

        private void CreateOrLoadCurrencyRegister(int amount)
        {
            if (!PlayerPrefs.HasKey("Player_Currency_" + type.ToString()))
            {
                PlayerPrefs.SetInt("Player_Currency_" + type.ToString(), amount);
            }
            else
            {
                this.amount = PlayerPrefs.GetInt("Player_Currency_" + type.ToString());
            }
        }
        public void Save()
        {
            PlayerPrefs.SetInt("Player_Currency_" + type.ToString(), amount);
        }
    }
}

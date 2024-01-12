using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemSO", menuName = "TapEquip/ShopItemSO")]
public class ShopItemSO : ScriptableObject
{
    public CurrencyManager.Currency currencyCost;
    public Sprite sprite;
    public GameObject item;

}
public class ShopItemAttribute : PropertyAttribute
{

}
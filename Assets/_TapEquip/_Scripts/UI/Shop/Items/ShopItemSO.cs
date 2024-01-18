using UnityEngine;

public abstract class ShopItemSO : ScriptableObject
{
    public CurrencyManager.Currency currencyCost;
    public Sprite sprite;
    public string itemName;
    public string itemDescription;
}
public class ShopItemAttribute : PropertyAttribute
{

}
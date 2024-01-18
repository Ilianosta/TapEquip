using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image itemImage;
    [SerializeField] private ShopItemSO item;
    public ShopItemSO Item
    {
        get { return item; }
        set { item = value; }
    }
    public void ShowShopDescription(bool show) => UIManager.instance.ShopScreen.ShowShopItemDescription(show, item);

    public void BuyItem()
    {
        // CurrencyManager.Currency myCurrency = CurrencyManager.instance.GetCurrency(item.currencyCost.type);
        // Debug.Log("YOU NEED: " + item.currencyCost.type.ToString() + " " + item.currencyCost.amount);
        // Debug.Log("AND YOU HAVE: " + myCurrency.type.ToString() + " " + myCurrency.amount);
        if (CurrencyManager.instance.HasEnoughCurrency(item.currencyCost.type, item.currencyCost.amount))
        {
            CurrencyManager.instance.ModifyCurrency(item.currencyCost.type, -item.currencyCost.amount);
            Debug.Log("BUYING ITEM!");
        }
        else
        {
            Debug.Log("YOU HASN'T ENOUGH CURRENCY FOR THIS ITEM!");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ShowShopDescription(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ShowShopDescription(false);
    }
}

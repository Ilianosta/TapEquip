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
    private void Awake()
    {

    }
    public void ShowShopDescription(bool show) => UIManager.instance.ShopScreen.ShowShopItemDescription(show, item);

    public void BuyItem()
    {

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

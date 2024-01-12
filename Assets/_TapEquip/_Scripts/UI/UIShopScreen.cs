using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopScreen : MonoBehaviour
{
    [SerializeField] private GameObject shopItemPrefab;
    [SerializeField] private Transform shopItemsParent;
    [SerializeField] private List<ShopItem> shopItems = new List<ShopItem>();
    private const string SHOP_ITEMS_FOLDER = "_ScriptableObjects/ShopItems/";
    private void Awake()
    {
        InstantiateShopItems();
    }

    private void InstantiateShopItems()
    {
        ShopItemSO[] shopItemDataArray = Resources.LoadAll<ShopItemSO>(SHOP_ITEMS_FOLDER);

        foreach (ShopItemSO shopItemData in shopItemDataArray)
        {
            GameObject shopItemGO = Instantiate(shopItemPrefab, shopItemsParent);
            ShopItem shopItemComponent = shopItemGO.GetComponent<ShopItem>();

            if (shopItemComponent != null)
            {
                shopItemComponent.Item = shopItemData;
                shopItems.Add(shopItemComponent);
            }
            else
            {
                Debug.LogError("The prefab doesn't have the script ShopItem");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopScreen : MonoBehaviour
{
    [SerializeField] private GameObject _shopItemPrefab;
    [SerializeField] private Transform _shopItemsParent;
    [SerializeField] private List<ShopItem> _shopItems = new List<ShopItem>();
    [SerializeField] private UISkillDescription _skillDescriptionPanel;
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
            GameObject shopItemGO = Instantiate(_shopItemPrefab, _shopItemsParent);
            ShopItem shopItemComponent = shopItemGO.GetComponent<ShopItem>();

            if (shopItemComponent != null)
            {
                shopItemComponent.Item = shopItemData;
                _shopItems.Add(shopItemComponent);
            }
            else
            {
                Debug.LogError("The prefab doesn't have the script ShopItem");
            }
        }
    }

    public void ShowShopItemDescription(bool show, ShopItemSO shopItem = null)
    {
        if (shopItem != null) _skillDescriptionPanel.SetShopItemDescription(shopItem);
        _skillDescriptionPanel.gameObject.SetActive(show);
    }
}

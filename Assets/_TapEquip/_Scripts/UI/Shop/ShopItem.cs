using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private ShopItemSO item;
    public ShopItemSO Item
    {
        get { return item; }
        set { item = value; }
    }

    public void BuyItem()
    {

    }
}

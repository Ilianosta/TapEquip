using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UISkillDescription : MonoBehaviour
{
    [SerializeField] private Image _skillImg;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;

    public void SetShopItemDescription(ShopItemSO shopItem)
    {
        _skillImg.sprite = shopItem.sprite;
        _name.text = shopItem.itemName;
        _description.text = shopItem.itemDescription;
    }
}

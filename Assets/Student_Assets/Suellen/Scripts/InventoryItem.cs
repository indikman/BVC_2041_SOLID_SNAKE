using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text itemName;

    public ItemSO itemSO;

    public void DisplayItemData(ItemSO itemData)
    {
        itemImage.sprite = itemData.sprite;
        itemName.text = itemData.name;
        itemSO = itemData;
    }
}

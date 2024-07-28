using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform itemsParent;
    [SerializeField] private GameObject inventoryUIItemPrefab;
    [SerializeField] private ItemDetailUI itemDetailUI; 

    private void OnEnable()
    {
        RefreshInventoryUI();
    }

    public void RefreshInventoryUI()
    {
        foreach (Transform child in itemsParent)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in inventory.GetItems())
        {
            GameObject itemGO = Instantiate(inventoryUIItemPrefab, itemsParent);
            Button button = itemGO.GetComponent<Button>();
            button.GetComponentInChildren<Image>().sprite = item.Icon;
            button.GetComponentInChildren<Text>().text = item.ItemName;

            // To add clicklistener
            button.onClick.AddListener(() => ShowItemDetails(item));
        }
    }

    private void ShowItemDetails(Item item)
    {
        itemDetailUI.UpdateItemDetails(item);
    }
}



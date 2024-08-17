using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[Serializable]
public class ItemClickedEvent : UnityEvent<InventoryDataSO> { }

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private GameObject itemButton;
    public List<InventoryDataSO> items;
    public InventoryManager inventoryManager;

    public ItemClickedEvent OnItemClicked;

    private void OnEnable()
    {
        inventoryManager.OnAddItem += AddItem;
    }

    private void OnDisable()
    {
        inventoryManager.OnAddItem -= AddItem;
    }

    private void AddItem(InventoryDataSO itemData)
    {
        items.Add(itemData);
        GameObject newItem = Instantiate(itemButton, transform);
        InventoryUIDisplay icon = newItem.GetComponent<InventoryUIDisplay>();
        icon.DisplayImage(itemData);

        Button button = newItem.GetComponent<Button>();
        button.onClick.AddListener(() => inventoryManager.ActivateItem(itemData));
    }
}

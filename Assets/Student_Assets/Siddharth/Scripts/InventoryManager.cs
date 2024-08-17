using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public event Action<InventoryDataSO> OnAddItem;
    public event Action<InventoryDataSO> OnItemPicked;

    [SerializeField] private List<InventoryDataSO> items = new List<InventoryDataSO>();

    private void StartInventory()
    {
        foreach (InventoryDataSO item in items)
        {
            OnAddItem?.Invoke(item);
        }
    }

    private void Start()
    {
        StartInventory();
    }

    public void AddItem(InventoryDataSO item)
    { 
        items.Add(item);
        item.inventoryManager = this;
        OnAddItem?.Invoke(item);
    }

    public void ActivateItem(InventoryDataSO item)
    {
        foreach (InventoryDataSO i in items)
        {
            i.isActive = false;
        }
        
        item.isActive = true;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public event Action<InventoryDataSO> OnInventoryLoaded;
    public event Action<InventoryDataSO> OnItemSelected;

    [SerializeField] private List<InventoryDataSO> items = new List<InventoryDataSO>();

    private void LoadItems()
    {
        foreach (InventoryDataSO item in items)
        {
            OnInventoryLoaded?.Invoke(item);
        }
    }

    private void Start()
    {
        LoadItems();
    }

    public void SelectItem(InventoryDataSO item)
    { 
        OnItemSelected?.Invoke(item);
    }
}

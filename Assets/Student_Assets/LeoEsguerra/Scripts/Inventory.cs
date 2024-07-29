using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Inventory class that holds items
public class Inventory : MonoBehaviour
{
    private ItemSO _activeItem;
    public event Action<ItemSO> OnItemsLoaded;
    public event Action<ItemSO> OnItemSelected;
    [SerializeField] private List<ItemSO> _items = new List<ItemSO>();

    // Load items to inventory UI if there are any
    private void LoadItems()
    {
        foreach (ItemSO item in _items)
        {
            OnItemsLoaded?.Invoke(item);
        }
    }

    private void Start()
    {
        LoadItems();
    }


    // Add item to inventory
    public void AddItem(ItemSO item)
    {
        _items.Add(item);
        OnItemsLoaded?.Invoke(item);
    }

    // Remove item from inventory
    public void RemoveItem(ItemSO item)
    {
        _items.Remove(item);
    }

    // Select item from inventory
    public void SelectItem(ItemSO item)
    {
        _activeItem = item;
        OnItemSelected?.Invoke(item);
    }
}

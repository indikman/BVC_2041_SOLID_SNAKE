using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PlayerInventory : MonoBehaviour
{
    public event Action<ItemSO> OnItemLoaded;
    public event Action<ItemSO> OnItemSelected;
    public event Action<ItemSO> OnItemPicked;
    //public event Action<ItemSO> OnItemUsed;

    private List<ItemSO> _items = new List<ItemSO>();
    private ItemSO _selectedItem;
    private ItemSO _pickedItem;

    void Start()
    {
        LoadItems();
    }

    private void LoadItems()
    {
        foreach (var item in _items)
        {
            OnItemLoaded?.Invoke(item);
        }
    }

    public void DisplayItemDetail(ItemSO item)
    {
        _selectedItem = item;
        OnItemSelected?.Invoke(_selectedItem);
    }

    public void PickItem()
    {
        if (_selectedItem)
        {
            _pickedItem = _selectedItem;
            OnItemPicked?.Invoke(_pickedItem);
            Debug.Log($"Picked item {_pickedItem.name}");
        }
    }

    public void AddItem(ItemSO item)
    {
        _items.Add(item);
        OnItemLoaded?.Invoke(item);
    }

    public void RemoveItem(ItemSO item)
    {
        _items.Remove(item);
        //OnItemUsed?.Invoke(item);
    }
}

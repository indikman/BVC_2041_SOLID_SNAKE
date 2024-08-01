using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Managers;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    public static event Action<List<InventoryItem>> OnInventoryChanged;
    
    public List<InventoryItem> InventoryItems = new List<InventoryItem>();
    private Dictionary<ItemData, InventoryItem> _itemDict = new Dictionary<ItemData, InventoryItem>();

    private void OnEnable()
    {
        Key.OnKeyCollected += Add;
        Coin.OnCoinCollected += Add;
        CrabSoda.OnSodaCollected += Add;
        VendingMachine.OnCoinSpent += Remove;
    }

    private void OnDisable()
    {
        Key.OnKeyCollected -= Add;
        Coin.OnCoinCollected -= Add;
        CrabSoda.OnSodaCollected -= Add;
        VendingMachine.OnCoinSpent -= Remove;
    }

    public void Add(ItemData itemData)
    {
        if (_itemDict.TryGetValue(itemData, out InventoryItem item))
        {
            item.AddToStack();
            Debug.Log($"{item.ItemData.DisplayName} total stack is now {item.StackSize}");
            OnInventoryChanged?.Invoke(InventoryItems);
        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemData);
            InventoryItems.Add(newItem);
            _itemDict.Add(itemData, newItem);
            Debug.Log($"{itemData.DisplayName} Added to inventory");
            OnInventoryChanged?.Invoke(InventoryItems);
        }
    }

    public void Remove(ItemData itemData)
    {
        if (_itemDict.TryGetValue(itemData, out InventoryItem item))
        {
            item.RemoveFromStack();
            if (item.StackSize <= 0)
            {
                InventoryItems.Remove(item);
                _itemDict.Remove(itemData);
            }
            
            OnInventoryChanged?.Invoke(InventoryItems);
        }
    }

    public bool HasItem(ItemData itemData)
    {
        return _itemDict.ContainsKey(itemData) && _itemDict[itemData].StackSize > 0;
    }
}

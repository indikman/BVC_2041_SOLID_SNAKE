using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    private static Inventory _instance;
    public static Inventory Instance => _instance;

    public int MaxSlots = 3;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public UnityEvent OnInventoryChanged = new UnityEvent();

    private List<InventoryItem> items = new List<InventoryItem>();

    public bool AddItem(InventoryItem item)
    {
        if (items.Count >= MaxSlots)
        {
            Debug.Log("CANT ADD MORE ELEMENTS!");
            return false;
        }
        items.Add(item);
        OnInventoryChanged.Invoke();
        return true;
    }

    public void RemoveItem(InventoryItem item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            OnInventoryChanged.Invoke();
        }
    }

    public List<InventoryItem> GetItems()
    {
        return new List<InventoryItem>(items); // Return a copy to prevent external modification
    }

    public void DropItem(InventoryItem item, Transform playerTransform)
    {
        if (items.Contains(item))
        {
            Vector3 dropDirection = -playerTransform.forward;

            Vector3 dropPosition = playerTransform.position + dropDirection * 2;
            Instantiate(item.itemPrefab, dropPosition, Quaternion.identity);
            RemoveItem(item);
        }
    }
}
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    private static Inventory _instance;
    public static Inventory Instance => _instance;

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

    public void AddItem(InventoryItem item)
    {
        items.Add(item);
        OnInventoryChanged.Invoke();
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
            // Calculate the direction opposite to the player's forward direction
            Vector3 dropDirection = -playerTransform.forward;

            // Calculate the drop position behind the player
            Vector3 dropPosition = playerTransform.position + dropDirection * 2;

            // Instantiate the item's prefab in the world at the drop position
            Instantiate(item.itemPrefab, dropPosition, Quaternion.identity);

            // Remove the item from the inventory
            RemoveItem(item);
        }
    }
}
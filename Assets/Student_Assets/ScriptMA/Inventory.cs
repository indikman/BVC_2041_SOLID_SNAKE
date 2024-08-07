using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{

    public List<InSO> items = new List<InSO>(); // List to store the inventory items.
    public UnityEvent onInventoryChanged; // Event to notify when the inventory changes.

    // Method to add an item to the inventory.
    public void AddItem(InSO item)
    {
        items.Add(item);
        onInventoryChanged.Invoke(); // Invoke the inventory changed event.
    }

    // Method to remove an item from the inventory.
    public void RemoveItem(InSO item)
    {
        items.Remove(item);
        onInventoryChanged.Invoke(); // Invoke the inventory changed event.
    }
}
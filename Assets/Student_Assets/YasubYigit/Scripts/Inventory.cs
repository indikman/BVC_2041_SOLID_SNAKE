using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>(); // List about store

    
    public void AddItem(Item item)
    {
        items.Add(item);
        // You can trigger UI updates here too
    }

    
    public void RemoveItem(Item item)
    {
        items.Remove(item);
        // You can trigger UI updates here to
    }

    
    public List<Item> GetItems()
    {
        return items;
    }
}


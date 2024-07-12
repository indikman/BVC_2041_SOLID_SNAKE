using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<ItemSO> items = new List<ItemSO>();

    public void AddItem(ItemSO item)
    {
        items.Add(item);
    }

    public void RemoveItem(ItemSO item)
    {
        items.Remove(item);
    }
}

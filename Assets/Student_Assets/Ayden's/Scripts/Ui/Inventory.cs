using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [field: SerializeField]
    public List<GameObject> InventoryObjects { get; private set; } = new List<GameObject>();
    
    public void AddItemsToInventoryList(GameObject itemToAdd)
    {
        InventoryObjects.Add(itemToAdd);
    }
}


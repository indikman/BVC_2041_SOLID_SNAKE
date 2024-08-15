using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private GameObject itemSlot;

    private List<GameObject> items;

    public InventoryManager inventoryManager;

    public event Action<InventoryDataSO> OnItemsLoaded;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void AddItem (InventoryDataSO data)
    {
        GameObject item = Instantiate(itemSlot);
        Button button = item.GetComponent<Button>();
        
    }
}

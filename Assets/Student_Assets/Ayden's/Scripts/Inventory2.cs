using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory2 : MonoBehaviour
{
    public Dictionary<AddObjectButton, int> PlayerItems = new Dictionary<AddObjectButton, int>();

    public Dictionary<ItemStats, int> PlayerStats = new Dictionary<ItemStats, int>();

    private AddObjectButton objectButton;

    private ItemStats ItemStats;

    private TheInventory theInventory;

    public int itemCount = 1;
    public void CreateInventorySlot(AddObjectButton _objectButton )
    {
        bool exists = PlayerItems.TryAdd(_objectButton, 1);
        if (exists)
        {
            objectButton = _objectButton;
            Debug.Log("Fucking doesn't exists");
            Instantiate(_objectButton,
                new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,
                    gameObject.transform.position.z), Quaternion.identity, theInventory.transform);
        }
        else
        {
            Debug.Log("Fucking exists");
            return;
        }
    }

    public void AddItemStats(ItemStats itemStats)
    {
        itemStats.IncreaseCount(itemCount);
        Debug.Log("increase");

        bool exists = PlayerStats.TryAdd(itemStats, 1);
        if (exists)
        {
            Instantiate(itemStats,
                new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,
                    gameObject.transform.position.z), Quaternion.identity, theInventory.transform);
        }

    }
    

    private void Start()
    {
        theInventory = FindObjectOfType<TheInventory>();
        
    }
    
    // change view of item on press, if key pressed disable item buttons and change to description and count, press again to renable.
}

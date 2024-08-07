using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory2 : MonoBehaviour
{
    public Dictionary<AddObjectButton, int> PlayerItems = new Dictionary<AddObjectButton, int>();

    private AddObjectButton objectButton;

    private TheInventory theInventory;
    
    public void CreateInventorySlot(AddObjectButton _objectButton )
    {
        bool exists = PlayerItems.TryAdd(_objectButton, 1);
        if (exists)
        {
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

    private void Start()
    {
        theInventory = FindObjectOfType<TheInventory>();
    }
}

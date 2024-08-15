using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class InventoryUIDisplay : MonoBehaviour
{
    
    public InventoryDataSO inventoryData;
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(inventoryData.itemDescription);
        //inventoryData.icon = Sprite();

        //Debug.Log(inventoryData.itemName);
    }

    
}

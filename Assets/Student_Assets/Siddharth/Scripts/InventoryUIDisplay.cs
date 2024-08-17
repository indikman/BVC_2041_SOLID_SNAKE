using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class InventoryUIDisplay : MonoBehaviour
{
    public Image itemImage;
    public InventoryDataSO inventoryData;
    public void DisplayImage(InventoryDataSO item)
    {
        inventoryData = item;
        itemImage.sprite = item.icon;
    }
}

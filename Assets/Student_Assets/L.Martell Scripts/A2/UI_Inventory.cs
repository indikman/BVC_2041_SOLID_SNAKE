using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    [Header ("Callback to Scripts")]
    public Item_Grab itemGrab;
    public Items_On_Inventory itemsOnInventory;

    [Header ("UI Information")]
    public GameObject inventorySlot;
    public Image image;
    public TMP_Text imageTitle;
    public TMP_Text imageDescription;

    public event Action <bool> ItemUsedEvent; 

    
    private bool _itemUsed;
    public bool ItemUsed
    {
        get=> _itemUsed;
        set
        {
            _itemUsed = value; 
            ItemUsedEvent?.Invoke(_itemUsed); 
            
        }
    }


    public void Update()
    {
        foreach(var itemList in itemsOnInventory.itemList)
            itemGrab.ItemGrabEvent += DisplayItem;
        
        ItemUsedEvent += InventoryUpdate; 
    }

    private void DisplayItem(bool value)
    {
        if(value == true)
        {
            image.sprite = itemGrab.icon;
            imageTitle.text = string.Format(itemGrab.item);
            imageDescription.text = string.Format(itemGrab.description);
        }
    }

    private void InventoryUpdate (bool value)
    {
        if(value == true)
            Destroy(inventorySlot);
    }

    public void OnUseInventoryItemClick()
    {
        ItemUsed = true;
    }
}
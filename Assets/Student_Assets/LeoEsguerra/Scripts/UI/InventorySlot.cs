using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class InventorySlot : Button
{
    public Image icon;
    public ItemSO item;

    public InventorySlot()
    {
        //Create a new Image element and add it to the root
        icon = new Image();
        Add(icon);

        //Add USS style properties to the elements
        icon.AddToClassList("slotIcon");
        AddToClassList("slotContainer");
    }

    public void Update(ItemSO item)
    {   
        this.item = item;
        icon.sprite = item.itemIcon;
    }
}
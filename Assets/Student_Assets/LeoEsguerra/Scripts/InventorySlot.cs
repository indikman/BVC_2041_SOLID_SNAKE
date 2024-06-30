using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventorySlot : VisualElement
{
    public Image icon;

    public InventorySlot()
    {
        //Create a new Image element and add it to the root
        icon = new Image();
        Add(icon);

        //Add USS style properties to the elements
        icon.AddToClassList("slotIcon");
        AddToClassList("slotContainer");
    }
}
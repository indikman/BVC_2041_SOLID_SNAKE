using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailUI : MonoBehaviour
{
    [SerializeField] private Text itemNameText;         // UI Text for item name
    [SerializeField] private Text itemDescriptionText;  // UI Text for item description
    [SerializeField] private Image itemIcon;            // UI Image for item icon

    // Method to update UI elements with item details
    public void UpdateItemDetails(Item item)
    {
        itemNameText.text = item.ItemName;                // Set item name
        itemDescriptionText.text = item.Description;      // Set item description
        itemIcon.sprite = item.Icon;                       // Set item icon
    }
}


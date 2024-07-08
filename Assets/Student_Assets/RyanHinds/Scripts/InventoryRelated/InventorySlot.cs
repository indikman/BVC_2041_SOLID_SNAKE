using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image Icon;
    [SerializeField] private TextMeshProUGUI StackSizeText;
    [SerializeField] private TextMeshProUGUI LabelText;

    public void ClearSlot()
    {
        Icon.enabled = false;
        StackSizeText.enabled = false;
        LabelText.enabled = false;
    }

    public void DrawSlot(InventoryItem item)
    {
        if (item == null)
        {
            ClearSlot();
            return;
        }

        Icon.enabled = true;
        StackSizeText.enabled = true;
        LabelText.enabled = true;

        Icon.sprite = item.ItemData.Icon;
        LabelText.text = item.ItemData.DisplayName;
        StackSizeText.text = item.StackSize.ToString();
    }
}

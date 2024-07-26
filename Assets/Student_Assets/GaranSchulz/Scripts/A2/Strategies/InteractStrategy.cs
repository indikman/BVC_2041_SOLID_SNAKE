using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractStrategy : MonoBehaviour
{
    [SerializeField] private MenuItemSO _equippedItem;
    private IStrategy _interaction;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _equippedItem.ItemSelected.Interact();
        }
    }
}

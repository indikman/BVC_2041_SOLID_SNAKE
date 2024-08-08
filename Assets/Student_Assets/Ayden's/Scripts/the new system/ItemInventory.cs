using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemInventory : MonoBehaviour
{
    private EventManager2 _eventManager2;
    private InventoryButton _inventoryButton;
    public ItemSO _itemSo;

    private void Start()
    {
        _eventManager2 = FindObjectOfType<EventManager2>();
        _eventManager2._ManagedEvent += AddItem;
    }

    public void AddItem()
    {
        _inventoryButton = _itemSo.inventoryButton;
        _inventoryButton._itemSo = _itemSo;
        Instantiate(_inventoryButton, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, transform);

    }
    
}

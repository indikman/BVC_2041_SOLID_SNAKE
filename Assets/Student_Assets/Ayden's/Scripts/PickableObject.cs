using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PickableObject : MonoBehaviour
{
    private bool _pickedUp = false;

    private ItemController _itemController;
    
    public ItemSO item;

    private Image _sprite;
    
    private Inventory _playerInventory;

    [SerializeField] private int despawnTime;
    

    private int _value = 1;

    private void Start()
    {
        _sprite = item.itemSprite;
        _itemController = FindObjectOfType<ItemController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_pickedUp)
        {
            return;
        }
        if (other.CompareTag("Player"))
        {
            _itemController.SpriteValueChanged(_sprite);
            _itemController.CountValueChanged(_value);
            _itemController.IncItemValue(_value);
            _itemController.ChangeSpriteValue(_sprite);
            _pickedUp = true;
            Destroy(this.gameObject, despawnTime);
        }
        else
        {
            return;
        }
    }
}

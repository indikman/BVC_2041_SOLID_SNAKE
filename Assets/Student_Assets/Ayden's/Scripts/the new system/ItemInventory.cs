using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemInventory : MonoBehaviour
{
    private EventManager2 _eventManager2;
    private GameObject _inventoryButton;
    public ItemSO _itemSo;
    public int _count;
    private Dictionary<GameObject, int> Buttons = new Dictionary<GameObject, int>();

    private void Start()
    {
        _count = 0;
        Reset();
        _eventManager2 = FindObjectOfType<EventManager2>();
        _eventManager2._ManagedEvent += IncreaseCount;
        _eventManager2._ManagedEvent += AddItem;
        Debug.Log(_count);
    }

    private void Reset()
    {
        _count = 0;
    }

    public void AddItem()
    {
        _inventoryButton = _itemSo.inventoryButton;
        bool exists = Buttons.TryAdd(_inventoryButton, 1);
        if (exists)
        {
            GameObject newInventory = Instantiate(_inventoryButton, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, transform);
        }
        else
        {
            Debug.Log("allready exists");
        }


    }

    public void IncreaseCount()
    {
        Debug.Log(_count);
        _count++;
        Debug.Log(_count);
    }
    
}

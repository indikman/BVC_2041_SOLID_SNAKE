using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    private EventManager2 _eventManager2;

    [SerializeField]private GameObject _itemInventory;

    private bool _inventoryOpen;

    private Aydens _gameInput;
    // Start is called before the first frame update
    void Start()
    {
        _eventManager2 = FindObjectOfType<EventManager2>();
        _gameInput = new Aydens();
        _inventoryOpen = true;
    }

    void OnInventory()
    {
        if (_inventoryOpen)
        {
            _itemInventory.SetActive(false);
            _inventoryOpen = false;
        }
        else
        {
            _itemInventory.SetActive(true);
            _inventoryOpen = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
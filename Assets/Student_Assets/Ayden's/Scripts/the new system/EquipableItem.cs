using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Interact();

public class EquipableItem : MonoBehaviour
{
    private Transform originalPosition;

    private Door _door;

    public ItemSO _itemSo;

    private ItemType _itemType;
    
    [SerializeField] private float detectionRadius;

    private ItemManager _itemManager;

    private bool canOpen;
    
    public Aydens useKey;

    public AudioInteractable _micro;
    
    

    private void Start()
    {
        originalPosition = FindObjectOfType<hands>().transform;
        transform.position = originalPosition.position;
        transform.rotation = originalPosition.rotation;
        _itemType = _itemSo.itemType;
        _itemManager = gameObject.AddComponent<ItemManager>();
        _door = FindObjectOfType<Door>();
        _micro = FindObjectOfType<AudioInteractable>();


    }

    private void Awake()
    {
        useKey = new Aydens();
    }

    private void FixedUpdate()
    {
        
        if (_door != null && _itemType == ItemType.Key)
        {
            float distance = Vector3.Distance(_door.transform.position, this.transform.position);
            if (distance <= detectionRadius)
            {
                _itemManager.InteractEvent += UseKey;
                canOpen = true;
            }
            else
            {
                _itemManager.InteractEvent -= UseKey;
                canOpen = false;
            }
        }
        else if (_micro != null && _itemType == ItemType.Useless)
        {
            float distance = Vector3.Distance(_micro.transform.position, this.transform.position);
            if (distance <= detectionRadius)
            {
                _itemManager.InteractEvent += MicroWave;
                canOpen = true;
            }
            else
            {
                _itemManager.InteractEvent -= MicroWave;
                canOpen = false;
            }
        }

    }
    
    public void UseKey()
    {
        if (_itemType == ItemType.Key)
        {
            _door.Interact();
        }
    }

    public void MicroWave()
    {
        _micro.Trigger();
    }
    
    
    
    private void OnUseKey()
    {
        if(canOpen)
        {
            Debug.Log("KEY");
            _itemManager.RunInteract();
        }
        else
        {
            return;
        }

    }
    
    private void OnUnEquip()
    {
        Destroy(this.gameObject);
    }

}

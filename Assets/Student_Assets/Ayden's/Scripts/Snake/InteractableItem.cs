using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public delegate void Interact();
public class InteractableItem : MonoBehaviour
{
    public AddObjectButton AddObjectButton;
    private ItemManager _itemManager = new ItemManager();
    public Aydens useKey;
    [SerializeField] private Door _door;
    [SerializeField] private float detectionRadius;
    private bool canOpen;
    public Transform originalPosition;
    private AddObjectButton _addObjectButton;
    
    private void Start()
    {
        _door = FindObjectOfType<Door>();
        _addObjectButton = FindObjectOfType<AddObjectButton>();
        originalPosition = FindObjectOfType<hands>().transform;
        Vector3 currentPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
        currentPosition = originalPosition.position;
        transform.position = originalPosition.position;
        transform.rotation = originalPosition.rotation;
        AddObjectButton = FindObjectOfType<AddObjectButton>();


    }

    private void FixedUpdate()
    {
        
        if (_door != null)
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
        else
        {
            return;
        }

    }

    private void Awake()
    {
        useKey = new Aydens();

    }

    private void OnEnable()
    {
        useKey.Enable();
    }

    private void OnDisable()
    {
        useKey.Disable();
    }

    public void UseKey()
    {
        _door.Interact();
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
        AddObjectButton.Dequip();
        Destroy(this.gameObject);
    }
    
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public delegate void Interact();
public class InteractableItem : MonoBehaviour
{
    private ItemManager _itemManager = new ItemManager();
    [SerializeField] private bool IsKey;
    public Aydens useKey;
    [SerializeField] private Door _door;
    [SerializeField] private float detectionRadius;
    private bool canOpen;
    private void Start()
    {
        _door = FindObjectOfType<Door>();
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
}

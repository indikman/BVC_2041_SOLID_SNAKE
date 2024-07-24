using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single_Inventory_Object : MonoBehaviour
{
/*
    public InventoryManager inventoryManager;
    public IndividualInteractable individualInteractable;

    //public event Action <bool> pickedUpObjectEvent;

    private bool _pickedUpByPlayer; 
    public bool pickedUpByPlayer;
    {
        get=> _pickedUpByPlayer;
        set
        {
            _pickedUpByPlayer = value;
            individualInteractable.pickedUpObjectEvent?.Invoke(_pickedUpByPlayer); //send out the event that says, hey, dexterity has changed.
        }
    }
    
    void Awake()
    {
        individualInteractable.objectHasBeenGrabbed = pickedUpByPlayer;
    }
    
    void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<Collider>().gameObject.CompareTag("Player") && pickedUpByPlayer == false)
        {
            pickedUpByPlayer = true;
            individualInteractable.pickedUpObjectEvent += ObjectHasBeenPickedUpByPlayer;
        }
    }

    private void ObjectHasBeenPickedUpByPlayer(bool value)
    {
        value = true;
        individualInteractable.pickedUpObjectEvent?.Invoke(pickedUpByPlayer);
    }
*/
}
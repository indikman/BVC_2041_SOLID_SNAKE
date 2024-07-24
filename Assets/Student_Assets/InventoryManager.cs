using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //public Individual_Interactable individualInteractable;
    //public Collection_Of_Inventory_Objects collectionOfInventoryObjects;

    private void Update()
    {
        /*
        foreach(var interactbleObject in collectionOfInventoryObjects.interactbleObject)
        {
           individualInteractable.pickedUpObjectEvent += PlayerGrabbedAnObject;
        }
        */
    }

    private void PlayerGrabbedAnObject(bool value)
    {
        /*
        if(value == true)
        {
            Debug.Log("Statement is true"); //This is just for testing
        }

        if(value == false)
        {
            Debug.Log("Statement is false"); //This is just for testing
        }
        */
    }
}

/*
public event Action <bool> clickedOnObjectEvent; 


private bool _objectHasBeenClickedOn;
    public bool objectHasBeenClickedOn
    {
        get=> _objectHasBeenClickedOn;
        set
        {
            _objectHasBeenClickedOn = value; //This is to pass "objectHasBeenGrabbed" into other methods under the term of "value". 
            clickedOnObjectEvent?.Invoke(_objectHasBeenClickedOn); //This calls the "pickedUpObjectEvent" whenever the value of "objectHasBeenGrabbed" is changed
        }
    }
*/

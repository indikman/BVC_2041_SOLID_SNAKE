using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayInventoryItem : MonoBehaviour
{
    [Header ("Script References")]
    public Individual_Interactable individualInteractable;
    public Collection_Of_Inventory_Objects collectionOfInventoryObjects;

    [Header ("UI Information")]
    public GameObject inventorySlot;
    public Image image;
    public TMP_Text imageTitle;
    public TMP_Text imageDescription;

    public event Action <bool> inventoryItemHasBeenClickedEvent; 

    //"inventoryItemHasBeenClickedEvent" will be influenced by "inventoryItemHasBeenClickedOn" boolean and will call onto other methods
    //Because this event has <whatever paramater>, it must be influenced by a boolean
    //The reason we have to pass "inventoryItemHasBeenClickedOn" into other methods when we want to call a method based on the status of the event
    //Is because methods that wanna call on from this event can ONLY do achieve this if they have a boolean parameter to take in "inventoryItemHasBeenClickedOn" as a parameter

    private bool _inventoryItemHasBeenClickedOn;
    public bool inventoryItemHasBeenClickedOn
    {
        get=> _inventoryItemHasBeenClickedOn;
        set
        {
            _inventoryItemHasBeenClickedOn = value; //This is to pass "inventoryItemHasBeenClickedOn" into other methods under the term of "value"
            inventoryItemHasBeenClickedEvent?.Invoke(_inventoryItemHasBeenClickedOn); 
            //This calls the "inventoryItemHasBeenClickedEvent" whenever the value of "inventoryItemHasBeenClickedOn" is changed
        }
    }

    private void Update()
    {
        foreach(var interactbleObject in collectionOfInventoryObjects.interactbleObject)
        {
           individualInteractable.pickedUpObjectEvent += DisplayItem;
        }
    }

    private void DisplayItem(bool value) //Displaying the image sprite and texts from TextMeshPros
    {
        if(value == true)
        {
            image.sprite = individualInteractable.objectSprite;
            imageTitle.text = string.Format(individualInteractable.objectName);
            imageDescription.text = string.Format(individualInteractable.objectDescription);
        }
    
        if(value == false)
            Debug.Log("Image statement is false");
    }

    public void OnUseInventoryItemClick()
    {
        inventoryItemHasBeenClickedOn = true;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Individual_Interactable : MonoBehaviour
{
    public string objectName;
    public string objectDescription;
    public Sprite objectSprite;

    public event Action <bool> pickedUpObjectEvent; 

    //"pickedUpObjectEvent" will be influenced by "objectHasBeenGrabbed" boolean and will call onto other methods
    //Because this event has <whatever paramater>, it must be influenced by a boolean
    //The reason we have to pass "objectHasBeenGrabbed" into other methods when we want to call a method based on the status of the event
    //Is because methods that wanna call on from this event can ONLY do achieve this if they have a boolean parameter to take in "objectHasBeenGrabbed" as a parameter

    private bool _objectHasBeenGrabbed;
    public bool objectHasBeenGrabbed
    {
        get=> _objectHasBeenGrabbed;
        set
        {
            _objectHasBeenGrabbed = value; //This is to pass "objectHasBeenGrabbed" into other methods under the term of "value". 
            pickedUpObjectEvent?.Invoke(_objectHasBeenGrabbed); //This calls the "pickedUpObjectEvent" whenever the value of "objectHasBeenGrabbed" is changed
        }
    }

    void Update()
    {
        pickedUpObjectEvent += DestroySelf; //Calling the "DestroySelf" method
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<Collider>().gameObject.CompareTag("Player") && objectHasBeenGrabbed == false)
            objectHasBeenGrabbed = true;
    }

    private void DestroySelf(bool value)
    {
        if(value == true)
            Destroy(this.gameObject);
    }
}

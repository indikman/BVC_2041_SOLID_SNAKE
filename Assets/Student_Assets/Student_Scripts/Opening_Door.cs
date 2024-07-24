using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening_Door : MonoBehaviour
{
    public DisplayInventoryItem displayInventoryItem;

    private Vector3 _startRotation;
    private Vector3 forward;

    private float doorSpeed = 3.0f; 
    private float time; //Time tracking in how long it takes for the door to rotate

    private bool playerWantsToInteractWithDoor = false; //This boolean is to avoid triggering a collision more than one in "OnTriggerEnter"

    void Awake()
    {
        _startRotation = transform.rotation.eulerAngles;
        forward = transform.right;
    }    

    private void Update()
    {
        displayInventoryItem.inventoryItemHasBeenClickedEvent += OpenDoor; //Calling the "OpenDoor" method
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<Collider>().gameObject.CompareTag("Player") && playerWantsToInteractWithDoor == false)
            playerWantsToInteractWithDoor = true;
    }

    private void OpenDoor(bool value)
    {
        if(value == true && playerWantsToInteractWithDoor == true)
            StartCoroutine(OpenDoor());
    }

    private IEnumerator OpenDoor()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;

        endRotation = Quaternion.Euler(new Vector3(-90, 0, -90)); 

        float time = 0;

        while(time < 1) //Lerping the door's rotation over "time" 
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * doorSpeed;
        }
    }

}

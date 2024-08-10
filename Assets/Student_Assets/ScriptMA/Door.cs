using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
  
    private bool inRange = false;
    private float rotationSpeed = 10f;
    private float rotationAngle = 90f;
    private Quaternion OrignalRotation;
    private Quaternion TargetRotation;

    bool canOpen;
    // Start is called before the first frame update
    void Start()
    {
        OrignalRotation = transform.rotation;
        TargetRotation = Quaternion.Euler(transform.eulerAngles + Vector3.up * rotationAngle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
          
            canOpen = true;
        }

        if(canOpen) { OpenDoor(); }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }
    private void OpenDoor()
    {
        for (int i = 0; i < InventoryManager.Instance.items.Count; i++)
        {
            if (InventoryManager.Instance.items[i].itemName == "Key")
            {
                Debug.Log("OpenDoor");
                transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, Time.deltaTime * rotationSpeed);

            }
        }
    }
}





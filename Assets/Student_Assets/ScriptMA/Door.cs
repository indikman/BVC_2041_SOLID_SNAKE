using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject TheDoor;
    private bool inRange= false;
    private float speed = 5f;
    private Quaternion OrignalRotation;
    private  Quaternion TargetRotation;
    // Start is called before the first frame update
    void Start()
    {
        OrignalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && inRange) 
        {
            OpenDoor();
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inRange = false;   
    }
    private void OpenDoor()
    {
        for (int i=0;i< InventoryManager.Instance.items.Count;i++ )
        {
            if (InventoryManager.Instance.items[i].itemName == "Key")
            {
                Debug.Log("OpenDoor");
                StartRotate();
                
            }
        }
    }
    private void StartRotate()
    {
        
        TargetRotation = Quaternion.Euler(0, 90, 0)* OrignalRotation;
        TheDoor.transform.rotation = Quaternion.Slerp(OrignalRotation,TargetRotation,Time.deltaTime * speed);
    }
}

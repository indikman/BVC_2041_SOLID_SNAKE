using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
  
    private bool inRange = false;
    public InSO keyItem;
    public string itemNeeded;
   

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            if(CheckTask() != null)
            {
                DoTask();
            }
        }

        
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
    public virtual void DoTask() 
    {
        Debug.Log("OpenDoor");
        InventoryManager.Instance.RemoveItem(keyItem);
    }
    private InSO CheckTask()
    {
        for (int i = 0; i < InventoryManager.Instance.items.Count; i++)
        {
            Debug.Log(InventoryManager.Instance.items[i].itemName);
            if (InventoryManager.Instance.items[i].itemName == itemNeeded)
            {

                keyItem = InventoryManager.Instance.items[i];
                Debug.Log(keyItem.name);
                return keyItem;
            }
        }
        return null;
    }
}





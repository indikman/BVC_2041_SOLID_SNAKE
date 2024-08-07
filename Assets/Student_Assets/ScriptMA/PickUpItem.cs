using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    public InSO item;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryManager.Instance.AddItem(item);

            Destroy(gameObject); // Remove the item from the scene
        }
    }

   
}


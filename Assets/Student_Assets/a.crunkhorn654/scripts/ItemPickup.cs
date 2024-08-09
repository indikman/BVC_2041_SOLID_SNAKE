using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public PickupSO pickupSO;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player item collided");
            InventoryManager.Instance.PickUp(pickupSO);
            Destroy(gameObject);
        }
    }

 

}

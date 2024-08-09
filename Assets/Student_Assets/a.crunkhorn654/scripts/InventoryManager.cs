using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public List<PickupSO> InventoryContainer = new List<PickupSO>(); //set up a list for our items
    public List<Interactible> interactiblesInRange = new List<Interactible>();

    public static InventoryManager Instance; //setting an instance to grab it easier
    public InventorySlot slot1;
    public InventorySlot slot2;
    public InventorySlot slot3;
    public List<InventorySlot> slots = new List<InventorySlot>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        slots.Add(slot1);
        slots.Add(slot2);
        slots.Add(slot3);
    }

    public void PickUp(PickupSO pickupSO)
    {
        InventoryContainer.Add(pickupSO);
        bool itemPlaced = false;
        foreach (InventorySlot slot in slots)
        {
            if (slot.itemSO == null && !itemPlaced)
            {
                slot.AddItem(pickupSO);
                itemPlaced = true;
            }
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Interactible"))
        {
            Debug.Log("interaciblesdfaskjdh");
            interactiblesInRange.Add(collision.gameObject.GetComponent<Interactible>());
        }

    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<Interactible>())
        {
            interactiblesInRange.Remove(collision.gameObject.GetComponent<Interactible>());
        }
    }

}

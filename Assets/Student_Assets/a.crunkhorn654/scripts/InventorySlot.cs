using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using Unity.VisualScripting;

public class InventorySlot : MonoBehaviour
{
    public PickupSO itemSO;
    public Image itemIcon;
    public Button useItemButton;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;


    public void Awake()
    {
        useItemButton.gameObject.SetActive(false);
    }

    public void AddItem(PickupSO item)
    {
        Debug.Log("additem triggering");
        itemSO = item;
        itemIcon.sprite = itemSO.itemIcon;
        useItemButton.gameObject.SetActive(true);
        itemName.text = itemSO.itemName;
        itemDescription.text = itemSO.itemDescription;

    }

    public void RemoveItem(PickupSO item)
    {
        itemSO = null;
        itemIcon.sprite = null;
        useItemButton.gameObject.SetActive(false);
        itemName.text = null;
        itemDescription.text = null;

    }

    public void Interact()
    {
        if(InventoryManager.Instance.interactiblesInRange != null)
        {

        
        foreach (Interactible interactible in InventoryManager.Instance.interactiblesInRange)
        {
            Debug.Log(interactible);
            if (interactible.pickupSO == itemSO)
            {
                interactible.Interacted.Invoke();
                    if (interactible.consumesItem == true)
                    {
                        RemoveItem(interactible.pickupSO);
                    }
                    Debug.Log("invoking");
            }
        }

        }
        else
        {
            Debug.Log("no interactibles");
        }
    }

}

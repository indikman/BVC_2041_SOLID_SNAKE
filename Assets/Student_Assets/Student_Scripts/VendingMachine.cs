using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
   public DisplayInventoryItem displayInventoryItem;
   public GameObject temporaryPopUpText;

   private bool playerWantsToInteractWithMachine = false; //This boolean is to avoid triggering a collision more than one in "OnTriggerEnter"

   private float lifeTime = 3.0f;

    void Awake()
    {
        temporaryPopUpText.SetActive(false);
    }

   private void Update()
   {
        displayInventoryItem.inventoryItemHasBeenClickedEvent += PlayerUsedCoin; //Calling the "PlayerUsedCoin" method
   }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<Collider>().gameObject.CompareTag("Player") && playerWantsToInteractWithMachine == false)
            playerWantsToInteractWithMachine = true;
    }

   private void PlayerUsedCoin(bool value)
   {
        if(value == true)
        {
            temporaryPopUpText.SetActive(true);
            Destroy(temporaryPopUpText, lifeTime); //Destroying "temporaryPopUpText" after "lifeTime" seconds have passed
        }
   }
}

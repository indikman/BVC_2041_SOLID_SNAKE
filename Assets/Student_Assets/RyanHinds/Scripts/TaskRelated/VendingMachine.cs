using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour, IInteractable
{
    public static event Action<ItemData> OnCoinSpent;

    [SerializeField] private AudioClip coinSpent;
    [SerializeField] private ItemData crabSodaItemData;
    [SerializeField] private ItemData coinItemData;

    public void Interaction()
    {
        if (Inventory.Instance.HasItem(coinItemData))
        {
            AudioManager.Instance.PlaySoundEffect(coinSpent);
            OnCoinSpent?.Invoke(coinItemData);
            
            Inventory.Instance.Add(crabSodaItemData);
        }
        else
        {
            Debug.Log("You don't have enough coins, apologies");
        }
    }
}

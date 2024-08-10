using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : Interactable
{
    [SerializeField] ItemSO invItem;
    [SerializeField] ItemSelector inv;

    protected override void Awake()
    {
        base.Awake();
        Debug.Log("itemActive");
    }
    public override void Trigger()
    {
        Debug.Log("itemPickup!");

        InteractBegan?.Invoke();
        inv.allItems.Add(invItem);
        Destroy(gameObject);
        inv.reLoadItems();
        
        
    }

}

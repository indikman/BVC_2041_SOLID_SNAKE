using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : Interactable
{
    protected override void Awake()
    {
        base.Awake();
        Debug.Log("itemActive");
    }
    public override void Trigger()
    {
        Debug.Log("itemPickup!");
        InteractBegan?.Invoke();
        Destroy(gameObject);
    }

}

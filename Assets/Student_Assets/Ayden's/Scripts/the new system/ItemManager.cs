using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public void RunInteract()
    {
        InvokeInteract();
    }

    public event Interact InteractEvent;

    protected virtual void InvokeInteract()
    {
        InteractEvent?.Invoke();
    }
}

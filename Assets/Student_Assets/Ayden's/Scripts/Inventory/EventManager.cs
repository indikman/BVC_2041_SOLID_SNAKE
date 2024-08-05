using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class EventManager
{
    public event PickUp internalEvent;

    public void Run()
    {
        InvokeEvent();
    }

    public void RunInteract()
    {
        InvokeInteract();
    }

    public event Interact InteractEvent;

    protected virtual void InvokeInteract()
    {
        InteractEvent?.Invoke();
    }

    protected virtual void InvokeEvent()
    {
        internalEvent?.Invoke();
    }
}
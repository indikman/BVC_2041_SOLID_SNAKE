using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableEvent : MonoBehaviour
{
    public event PickUpEvent PickedEvent;

    public void RunPickUp()
    {
        InvokePickUp();
    }

    protected virtual void InvokePickUp()
    {
        PickedEvent?.Invoke();
    }
}

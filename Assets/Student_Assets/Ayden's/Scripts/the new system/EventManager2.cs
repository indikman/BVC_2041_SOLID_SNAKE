using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ManagedEvent();
public class EventManager2 : MonoBehaviour
{
    public event ManagedEvent _ManagedEvent;
    
    public void RunEvent()
    {
        InvokeEvent();
    }

    protected virtual void InvokeEvent()
    {
        _ManagedEvent?.Invoke();
    }
}

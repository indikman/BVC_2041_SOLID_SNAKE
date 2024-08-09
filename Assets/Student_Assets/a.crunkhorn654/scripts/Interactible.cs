using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactible : MonoBehaviour
{
    public PickupSO pickupSO;                           // define the object that activates this interactible, then the event that plays when the interaction occurs
    public UnityEvent Interacted = new UnityEvent();


}

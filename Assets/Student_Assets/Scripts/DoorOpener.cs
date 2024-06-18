using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private Animator frontDoor = null;
    [SerializeField] private bool openFrontDoor = false;

    [SerializeField] private Animator middleDoor = null;
    [SerializeField] private bool openMiddleDoor = false;
    public UnityEvent OpenDoor;

    public void OpenFrontDoor()
    {
        openFrontDoor = !openFrontDoor;
        frontDoor.SetBool("OpenFrontDoor", openFrontDoor);
        OpenDoor.Invoke();
      
    }
    public void OpenMiddleDoor()
    {
        openFrontDoor = !openMiddleDoor;
        frontDoor.SetBool("OpenMiddleDoor", openMiddleDoor);
        OpenDoor.Invoke();

    }
}

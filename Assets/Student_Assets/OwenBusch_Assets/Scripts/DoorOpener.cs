using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private WaitForFixedUpdate _fixedUpdate;

    [SerializeField] private Vector3 closedRotation;
    [SerializeField] private Vector3 openRotation;
    [SerializeField] private float openSpeed;
    
    public void OpenDoor()
    {
        StartCoroutine(LerpToRotation(openRotation));
    }
    
    public void CloseDoor()
    {
        StopAllCoroutines();
        StartCoroutine(LerpToRotation(closedRotation));
    }


    private IEnumerator LerpToRotation(Vector3 rotation)
    {
        while (transform.rotation != Quaternion.Euler(rotation))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rotation), openSpeed * Time.fixedDeltaTime);
            yield return _fixedUpdate;
        }
    }
}

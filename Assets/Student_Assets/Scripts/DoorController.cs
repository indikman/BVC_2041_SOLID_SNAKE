using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Vector3 _originalPosition;
    [SerializeField] private Vector3 openPosition;
    [SerializeField] private Vector3 closedPosition;
    [SerializeField] private float _speed = 1.25f;

    private void Awake()
    {
        _originalPosition = transform.position;
    }

    public void OpenDoor()
    {
        StartCoroutine(SwingDoor(openPosition));
    }

    public void CloseDoor()
    {
        StopCoroutine("SwingDoor");
        StartCoroutine(SwingDoor(closedPosition));
    }

    IEnumerator SwingDoor(Vector3 newRotation)
    {
        while (transform.rotation != Quaternion.Euler(newRotation))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(newRotation), _speed * Time.fixedDeltaTime);
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
    }
}

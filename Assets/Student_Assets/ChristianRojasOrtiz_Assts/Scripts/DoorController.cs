using System;
using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private float openAngle = 90f;
    [SerializeField] private float closeAngle = 0f;
    [SerializeField] private float duration = 2f;
    private bool isOpen = false;
    private Quaternion openRotation;
    private Quaternion closeRotation;

    private void Start()
    {
        openRotation = Quaternion.Euler(0, openAngle, 0);
        closeRotation = Quaternion.Euler(0, closeAngle, 0);
    }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //        OpenDoor();
    //     }
    //     if(Input.GetKeyUp(KeyCode.Space))
    //     {
    //         CloseDoor();
    //     }
    // }

    public void OpenDoor()
    {
        StopAllCoroutines();
        StartCoroutine(RotateDoor(openRotation));
    }

    public void CloseDoor()
    {
        StopAllCoroutines();
        StartCoroutine(RotateDoor(closeRotation));
    }

    private IEnumerator RotateDoor(Quaternion endRotation)
    {
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, endRotation, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = endRotation;
    }
}
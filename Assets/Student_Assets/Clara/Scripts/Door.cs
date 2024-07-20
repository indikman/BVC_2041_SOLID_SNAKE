using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float duration = 2.0f;
    [SerializeField] private float angle = 90.0f;
    [SerializeField] private float waitTime = 2f;
    [SerializeField] Transform doorPivot;

    public bool isOpening = false;
    public bool isClosing = false;

    private void Start()
    {
        if (doorPivot != null) 
        {
            doorPivot = transform;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            OpenDoor();
        }
    }
    public void OpenDoor()
    {
        if (!isOpening && !isClosing) 
        {
            StartCoroutine(DoorMove());
        }
    }
    private IEnumerator DoorMove()
    {
        isOpening = true;
        Quaternion firstRotation = doorPivot.rotation;
        Quaternion rotationMove = Quaternion.Euler(doorPivot.eulerAngles + new Vector3(0, angle, 0));

        for (float i = 0; i < duration; i += Time.deltaTime)
        {
            doorPivot.rotation = Quaternion.Slerp(firstRotation, rotationMove, i/duration);
            yield return null;
        }
        isOpening = false;

        yield return new WaitForSeconds(waitTime);
        isClosing = true;

        for (float i = 0; i < duration; i += Time.deltaTime)
        {
            doorPivot.rotation = Quaternion.Slerp(rotationMove, firstRotation, i / duration);
            yield return null;
        }

        isClosing = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float openAngle = 90f; 
    public float openDuration = 2f;
    public float closeDuration = 2f; 
    public float openWaitTime = 3f; 
    public Transform doorTransform; 

    private bool isOpening = false; 
    private bool isClosing = false; 

    void Start()
    {
        if (doorTransform == null)
        {
            doorTransform = transform;
        }
    }

    public void OpenDoor()
    {
        if (!isOpening && !isClosing)
        {
            StartCoroutine(OpenCloseDoor());
        }
    }

    private IEnumerator OpenCloseDoor()
    {
        isOpening = true;

        Quaternion initialRotation = doorTransform.rotation;
        Quaternion openRotation = Quaternion.Euler(doorTransform.eulerAngles + new Vector3(0, openAngle, 0));

        // Open 
        for (float t = 0; t < openDuration; t += Time.deltaTime)
        {
            doorTransform.rotation = Quaternion.Slerp(initialRotation, openRotation, t / openDuration);
            yield return null;
        }
        doorTransform.rotation = openRotation;

        isOpening = false;

        yield return new WaitForSeconds(openWaitTime);

        isClosing = true;

        // Close 
        for (float t = 0; t < closeDuration; t += Time.deltaTime)
        {
            doorTransform.rotation = Quaternion.Slerp(openRotation, initialRotation, t / closeDuration);
            yield return null;
        }
        doorTransform.rotation = initialRotation;

        isClosing = false;
    }
}

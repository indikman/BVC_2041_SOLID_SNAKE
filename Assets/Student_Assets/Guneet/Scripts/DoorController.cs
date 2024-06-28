using System;
using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen = false;  // State of the door
    public float rotationAngle = 90f;  // Angle to rotate when opening/closing
    public float rotationSpeed = 2f;  // Speed of rotation
    public Vector3 rotationAxis = Vector3.up;  // Axis to rotate around (default is Y axis)

    // Method to toggle the door state
    public void ToggleDoor()
    {
        isOpen = !isOpen;
        StopAllCoroutines();  // Stop any ongoing rotation
        StartCoroutine(RotateDoor(isOpen ? rotationAngle : -rotationAngle));
    }

    // Coroutine to smoothly rotate the door
    private IEnumerator RotateDoor(float angle)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.AngleAxis(angle, rotationAxis);
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            yield return null;
        }
        // Ensure the final rotation is exactly the target rotation
        transform.rotation = endRotation;
    }
}
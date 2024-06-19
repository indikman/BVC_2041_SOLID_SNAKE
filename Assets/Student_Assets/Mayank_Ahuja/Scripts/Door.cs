using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private float speed = 1.0f; // Rotation speed
    private bool isRotating = false;
    private Quaternion targetRotation;
    private Quaternion originalRotation;

    private void Start()
    {
        originalRotation = transform.rotation;
    }
    private void Update()
    {
        if (isRotating)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.rotation = targetRotation;
                isRotating = false;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isRotating)
        {
            Debug.Log("Collision Detected");
            targetRotation = Quaternion.Euler(0, 90, 0) * originalRotation; // Calculate the target rotation
            StartCoroutine(RotateDoor());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isRotating)
        {
            Debug.Log("Player Exited");
            targetRotation = originalRotation; // Set the target rotation back to the original
            StartCoroutine(RotateDoor());
        }
    }
    private IEnumerator RotateDoor()
    {
        isRotating = true;
        while (isRotating)
        {
            yield return null; // Wait for the next frame
        }
    }

}

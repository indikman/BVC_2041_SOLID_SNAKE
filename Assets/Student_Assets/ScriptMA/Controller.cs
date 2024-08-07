using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float rotationSpeed = 720f; // Degrees per second
    public Transform cameraTransform;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        // Get input from user
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate direction based on camera
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        direction = cameraTransform.TransformDirection(direction);
        direction.y = 0f; // Keep movement on the ground plane

        // Move the player
        Vector3 moveAmount = direction * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + moveAmount);
    }

    void Rotate()
    {
        // Get mouse input for rotation
        float mouseX = Input.GetAxis("Mouse X");

        // Calculate rotation amount
        Quaternion rotation = Quaternion.Euler(0f, mouseX * rotationSpeed * Time.deltaTime, 0f);

        // Apply rotation
        rb.MoveRotation(rb.rotation * rotation);
    }

}


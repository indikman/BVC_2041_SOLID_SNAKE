using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InteractableItem : MonoBehaviour
{
    private Door _door;
    [SerializeField] private bool IsKey;
    public Aydens useKey;
    private void Start()
    {
        _door = FindObjectOfType<Door>();
    }

    private void Awake()
    {
        useKey = new Aydens();
    }

    private void OnEnable()
    {
        useKey.Enable();
    }

    private void OnDisable()
    {
        useKey.Disable();
    }

    private void OnUseKey()
    {
        Debug.Log("KEY");
        _door.Interact();
    }
}

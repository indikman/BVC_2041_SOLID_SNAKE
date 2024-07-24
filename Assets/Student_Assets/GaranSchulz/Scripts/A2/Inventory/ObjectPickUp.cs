using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickUp : MonoBehaviour
{
    [SerializeField] private ObjectSO _object;
    private GameObject _ui;
    private void Awake()
    {
        _ui = GameObject.Find("[PlayerInventory]"); //This might end up a bit performant, but it should be fine?
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_object.IsPickedUp)
            return;
        _object.IsPickedUp = true;
        _object.PickupEvent();
    }
}

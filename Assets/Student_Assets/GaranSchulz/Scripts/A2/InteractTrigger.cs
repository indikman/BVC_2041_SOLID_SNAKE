using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Code.Scripts.SOs.Inputs;

public class InteractTrigger : MonoBehaviour
{
    [SerializeField] private MenuItemSO _equippedItem;
    [SerializeField] private ObjectSO _requiredObject;
    [SerializeField] private PlayerControlChannelSO _input;
    private bool _hasBeenActivated = false;
    public UnityEvent OnSuccessfulInteract;

    private void OnTriggerEnter(Collider other)
    {
        if (_hasBeenActivated)
            return;
        if (other.CompareTag("Player") && _equippedItem.ItemSelected != null && _requiredObject.ObjectName == _equippedItem.ItemSelected.ObjectName)
            _input.Interact2 += () => OnSuccessfulInteract.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            _input.Interact2 -= OnSuccessfulInteract.Invoke;
    }

    public void DisableCollider()
    {
        _input.Interact2 -= OnSuccessfulInteract.Invoke;
        _hasBeenActivated = true;
    }
}

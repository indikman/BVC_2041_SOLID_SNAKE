using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts.SOs.Inputs;
using UnityEngine;

public class InteractStrategy : MonoBehaviour
{
    [SerializeField] private MenuItemSO _equippedItem;
    [SerializeField] private PlayerControlChannelSO _control;
    private IStrategy _interaction;

    private void Awake()
    {
        _control.Interact2 += () => TestLog();
    }

    private void TestLog()
    {
        _equippedItem.ItemSelected.Interact();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUI : MonoBehaviour
{
    private List<InventorySlot> _inventory = new List<InventorySlot>();

    private VisualElement _root;
    private VisualElement _slotContainer;
    [SerializeField] private int _slotCount = 30;

    private void Awake()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
        _slotContainer = _root.Q<VisualElement>("SlotContainer");

        for (int i = 0; i < _slotCount; i++)
        {
            InventorySlot item = new InventorySlot();
            _inventory.Add(item);
            _slotContainer.Add(item);
        }
    }
}


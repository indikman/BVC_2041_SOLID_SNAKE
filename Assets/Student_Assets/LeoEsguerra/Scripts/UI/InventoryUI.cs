using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Code.Scripts.Managers;
using System;
using UnityEngine.Events;

public class InventoryUI : MonoBehaviour
{
    private List<InventorySlot> _inventory = new List<InventorySlot>();
    private VisualElement _root;
    private VisualElement _slotContainer;
    [SerializeField] private int _slotCount = 10;

    public Inventory inventory;


    // Add listener to inventory
    private void OnEnable()
    {    
        inventory.OnItemsLoaded += AddItem;
    }

    // Remove listener from inventory
    private void OnDisable()
    {
        inventory.OnItemsLoaded -= AddItem;
    }

    // Add item to inventory
    private void AddItem(ItemSO item)
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
        _slotContainer = _root.Q<VisualElement>("SlotContainer");

        // Create slot and add to inventory
        InventorySlot slot = new InventorySlot();
        slot.Update(item);
        _inventory.Add(slot);
        _slotContainer.Add(slot);
        slot.clicked += () => {
            inventory.SelectItem(slot.item);
            UpdatePreview(slot);
        };  
    }

    // Remove item from inventory
    public void RemoveItem(ItemSO item)
    {
        foreach (InventorySlot slot in _inventory)
        {
            if(slot.item == item)
            {
                slot.Update(null);
                break;
            }
        }
    }

    // Update item preview with selected item
    private void UpdatePreview(InventorySlot slot)
    {
        VisualElement preview = _root.Q<VisualElement>("Preview");
        Label name = preview.Q<Label>("Name");
        VisualElement image = preview.Q<VisualElement>("Image");
        Label description = preview.Q<Label>("Description");
        
        if(slot.item == null)
        {
            name.text = "";
            image.style.backgroundImage = null;
            description.text = "";
            return;
        }

        name.text = slot.item.itemName;
        description.text = slot.item.description;
        image.style.backgroundImage = new StyleBackground(slot.item.itemIcon.texture);
    }
}


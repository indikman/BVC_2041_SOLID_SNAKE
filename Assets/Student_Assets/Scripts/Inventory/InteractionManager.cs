using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private InventoryUI inventoryUI;
    private int _selectedSlotIndex = -1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSlot(3);
        }

        if (Input.GetKeyDown(KeyCode.E))  // Example interaction key
        {
            InteractWithSelectedItem();
        }
    }

    private void SelectSlot(int slotIndex)
    {
        InventorySlot[] slots = inventoryUI.GetSlots();

        if (slotIndex < slots.Length)
        {
            _selectedSlotIndex = slotIndex;
            InventoryItem selectedItem = slots[_selectedSlotIndex].GetItem();

            if (selectedItem != null)
            {
                Debug.Log($"Selected item: {selectedItem.itemName}");
            }
        }
    }

    private void InteractWithSelectedItem()
    {
        if (_selectedSlotIndex >= 0)
        {
            InventorySlot[] slots = inventoryUI.GetSlots();
            InventoryItem selectedItem = slots[_selectedSlotIndex].GetItem();

            if (selectedItem != null)
            {
                selectedItem.UseItem();
                Debug.Log($"Interacted with item: {selectedItem.itemName}");
            }
        }
    }
}
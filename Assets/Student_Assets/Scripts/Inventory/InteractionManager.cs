using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private float interactionRange = 3f;
    private int _selectedSlotIndex = -1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(0);
            InteractWithNearbyObject();

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(1);
            InteractWithNearbyObject();

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(2);
            InteractWithNearbyObject();

        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSlot(3);
            InteractWithNearbyObject();

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

    private void InteractWithNearbyObject()
    {
        if (_selectedSlotIndex >= 0)
        {
            InventorySlot[] slots = inventoryUI.GetSlots();
            InventoryItem selectedItem = slots[_selectedSlotIndex].GetItem();

            if (selectedItem != null)
            {
                // Detect objects within range
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactionRange);

                foreach (var hitCollider in hitColliders)
                {
                    InteractableObject interactable = hitCollider.GetComponent<InteractableObject>();
                    if (interactable != null && interactable.CanInteractWith(selectedItem))
                    {
                        interactable.Interact();
                        Debug.Log($"Interacted with item: {selectedItem.itemName} on {hitCollider.gameObject.name}");
                    }
                }
            }
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button dropButton;
    private InventoryItem item;

    private void Awake()
    {
        // Ensure dropButton is correctly assigned
        if (dropButton == null)
        {
            Debug.LogError("Drop button is not assigned in the Inspector for " + gameObject.name);
            return;
        }

        // Clear any existing listeners to prevent duplicate actions
        dropButton.onClick.RemoveAllListeners();

        // Add the drop item listener
        dropButton.onClick.AddListener(DropItem);
    }

    public void AddItem(InventoryItem newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        dropButton.gameObject.SetActive(true); // Enable drop button when an item is present
        Debug.Log($"Item added to slot: {item.itemName}");
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        dropButton.gameObject.SetActive(false); // Disable drop button when no item is present
        Debug.Log("Slot cleared");
    }

    public void OnItemSelected()
    {
        if (item != null)
        {
            Debug.Log($"Selected: {item.itemName} - {item.description}");
        }
    }

    private void DropItem()
    {
        if (item != null)
        {
            Debug.Log($"Dropping item: {item.itemName} from slot {gameObject.name}");
            Inventory.Instance.DropItem(item, FindObjectOfType<PlayerController>().transform);
        }
        else
        {
            Debug.LogWarning("Attempted to drop an item from an empty slot: " + gameObject.name);
        }
    }

    // Return the item in this slot
    public InventoryItem GetItem()
    {
        return item;
    }
}
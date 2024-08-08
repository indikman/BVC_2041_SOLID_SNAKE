using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform itemsParent;
    [SerializeField] private GameObject inventoryUI;
    private InventorySlot[] _slots;

    private void Start()
    {
        Inventory.Instance.OnInventoryChanged.AddListener(UpdateUI);
        _slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        UpdateUI();
    }

    private void UpdateUI()
    {
        List<InventoryItem> items = Inventory.Instance.GetItems();
        Debug.Log("TOTAL ITEMS: " + items.Count);

        for (int i = 0; i < _slots.Length; i++)
        {
            if (i < items.Count)
            {
                _slots[i].AddItem(items[i]);
            }
            else
            {
                _slots[i].ClearSlot();
            }
        }
    }

    // Return the array of slots
    public InventorySlot[] GetSlots()
    {
        return _slots;
    }
}
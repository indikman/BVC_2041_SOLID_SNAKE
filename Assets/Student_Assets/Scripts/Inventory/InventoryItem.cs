using UnityEngine;

[CreateAssetMenu(fileName = "NewInventoryItem", menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;
    public GameObject itemPrefab;
    public int Poing; // Assign a specific interaction type

    // Reference to an interaction script (strategy pattern)
    public IInteractable interaction; // Assign a specific interaction type

    // Method to perform interaction
    public void UseItem()
    {
        if (interaction != null)
        {
            interaction.Interact();
        }
    }
}
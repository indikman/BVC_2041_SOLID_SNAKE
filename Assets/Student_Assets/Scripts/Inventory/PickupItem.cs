using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private InventoryItem itemDetails;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided is the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("FOUND");
            // Add the item to the inventory
            Inventory.Instance.AddItem(itemDetails);

            // Optionally, destroy the item in the world after picking it up
            Destroy(gameObject);
        }
    }
}
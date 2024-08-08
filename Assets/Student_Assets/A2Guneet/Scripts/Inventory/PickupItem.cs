using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private InventoryItem itemDetails;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Inventory.Instance.AddItem(itemDetails))
            {
                Destroy(gameObject);
            }
        }
    }
}
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public InventoryItem InteractWith;
    public virtual void Interact(InventoryItem selectedItem)
    {
        Debug.Log("Interacting");

    }

    public virtual bool CanInteractWith(InventoryItem selectedItem)
    {
        if (InteractWith == selectedItem)
        {
            Debug.Log("Can Interact");
            return true;
        }

        return false;
    }
}


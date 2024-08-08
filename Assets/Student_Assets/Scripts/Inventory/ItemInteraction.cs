using UnityEngine;

public interface IInteractable
{
    void Interact();
}

public class KeyInteraction : IInteractable
{
    private Door _door;

    public KeyInteraction(Door door)
    {
        _door = door;
    }

    public void Interact()
    {
        if (_door != null)
        {
            _door.ToggleDoor();
            Debug.Log("Door toggled using key.");
        }
    }
}


public class DetergentInteraction : IInteractable
{
    public void Interact()
    {
        Debug.Log("Detergent added to the washing machine.");
    }
}

public class ItemInteraction : MonoBehaviour
{
    private IInteractable currentInteraction;

    public void SetInteraction(IInteractable interaction)
    {
        currentInteraction = interaction;
    }

    public void PerformInteraction()
    {
        currentInteraction?.Interact();
    }
}
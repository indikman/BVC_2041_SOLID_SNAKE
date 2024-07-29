using UnityEngine;

// Collectable class that inherits from Interactable
// This class is used for collectable objects in the game
// Destroy the object when the player collects it
public class Collectable : Interactable
{
    public override void Trigger()
    {
        InteractEnded?.Invoke();
        Destroy(gameObject);
    }
}

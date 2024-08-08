using UnityEngine;

public class InteractableSequenceObject : InteractableObject
{
    public InventoryItem[] interactSequence; // Sequence of items required
    private int currentSequenceIndex = 0;    // Track the current step in the sequence

    public AudioClip sequenceCompleteClip; 
    private AudioSource audioSource;

    private void Awake()
    {
       
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public override void Interact(InventoryItem selectedItem)
    {
        if (CanInteractWith(selectedItem))
        {
            Inventory.Instance.RemoveItem(selectedItem);
            currentSequenceIndex++;

            if (currentSequenceIndex >= interactSequence.Length)
            {
                CompleteInteraction();
                currentSequenceIndex = 0; // Reset sequence for future interactions
            }
        }
        else
        {
            Debug.Log("Incorrect item. Sequence reset.");
            currentSequenceIndex = 0; // Reset if the wrong item is used
        }
    }

    public override bool CanInteractWith(InventoryItem selectedItem)
    {
        return currentSequenceIndex < interactSequence.Length && interactSequence[currentSequenceIndex] == selectedItem;
    }

    private void CompleteInteraction()
    {
        Debug.Log("Interaction sequence completed!");
        PlayAudioClip(sequenceCompleteClip); // Play sequence completed sound
        
    }

    private void PlayAudioClip(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}

using System;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    public event Action<string, TriggerTaskEvent> OnInteraction;
    public TriggerTaskEvent task;

    private bool _hasPlayer;

    void Update()
    {
        if (_hasPlayer && Input.GetKeyDown(KeyCode.E))
        {
            OnInteraction?.Invoke(this.tag, task);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _hasPlayer = true;
            Interaction interaction = other.GetComponent<Interaction>();
            OnInteraction += interaction.ExecuteInteraction;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _hasPlayer = false;
            Interaction interaction = other.GetComponent<Interaction>();
            OnInteraction -= interaction.ExecuteInteraction;
        }
    }
}

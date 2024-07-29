using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts.SOs.Player;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class Interactable : MonoBehaviour
{
    public UnityEvent InteractBegan, InteractEnded;
    // Start is called before the first frame update
    protected bool _playing = false;
    protected bool _canInteract = true;
    [SerializeField] private ItemSO _requiredItem;
    [SerializeField] private Inventory inventory;
    protected virtual void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        if(_requiredItem != null)
        {
            _canInteract = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Add listener to inventory
    private void OnEnable()
    {    
        inventory.OnItemSelected += CheckCanInteract;
    }

    // Remove listener from inventory
    private void OnDisable()
    {
        inventory.OnItemSelected -= CheckCanInteract;
    }
    
    // Check if the player has the required item
    private void CheckCanInteract(ItemSO item)
    {
        if(_requiredItem != null)
        {
            _canInteract = item == _requiredItem;
        }
        else
        {
            _canInteract = true;
        }
    }

    void CheckInteract(Transform playerTransform)
    {
        float angle = Vector3.Dot(playerTransform.forward, (transform.position - playerTransform.position).normalized);
        if (angle > 0 && _canInteract)
        {
            Trigger();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out var player))
        {
            player.PlayerInteractions.InteractTriggered.AddListener(this.CheckInteract);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out var player))
        {
            player.PlayerInteractions.InteractTriggered.RemoveListener(this.CheckInteract);
        }
    }

    public virtual void Trigger()
    {
        
    }
}

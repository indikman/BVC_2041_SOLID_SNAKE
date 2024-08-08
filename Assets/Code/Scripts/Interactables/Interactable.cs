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
    protected bool _playing = false;
    protected virtual void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    void Update()
    {
        
    }
    
    void CheckInteract(Transform playerTransform)
    {
        
        float angle = Vector3.Dot(playerTransform.forward, (transform.position - playerTransform.position).normalized);
        if (angle > 0)
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

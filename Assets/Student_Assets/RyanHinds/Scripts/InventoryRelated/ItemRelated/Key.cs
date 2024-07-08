using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, ICollectible
{
    public static event HandleKeyCollection OnKeyCollected;
    public delegate void HandleKeyCollection(ItemData itemData);

    [SerializeField] public ItemData keyData;

    [SerializeField] private AudioClip keyPickupSound;
    
    public void Collect()
    {
        AudioManager.Instance.PlaySoundEffect(keyPickupSound);
        Destroy(this.gameObject);
        OnKeyCollected?.Invoke(keyData);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, ICollectible
{
    public static event HandleKeyCollection OnKeyCollected;
    public delegate void HandleKeyCollection(ItemData itemData);

    [SerializeField] public ItemData keyData;

    [SerializeField] private AudioClip keyPickup;
    
    public void Collect()
    {
        AudioManager.Instance.PlaySoundEffect(keyPickup);
        Destroy(this.gameObject);
        OnKeyCollected?.Invoke(keyData);
    }
}

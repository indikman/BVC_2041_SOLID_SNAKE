using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{
    public static event HandleCoinCollection OnCoinCollected;
    public delegate void HandleCoinCollection(ItemData itemData);

    [SerializeField] private ItemData coinData;
    [SerializeField] private AudioClip coinCollectSound;
    
    public void Collect()
    {
        AudioManager.Instance.PlaySoundEffect(coinCollectSound);
        Destroy(this.gameObject);
        OnCoinCollected?.Invoke(coinData);
    }
}

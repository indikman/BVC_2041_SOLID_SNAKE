using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabSoda : MonoBehaviour, ICollectible
{
    public static event HandleCrabSodaCollection OnSodaCollected;
    public delegate void HandleCrabSodaCollection(ItemData itemData);

    [SerializeField] private ItemData crabSodaItemData;
    [SerializeField] private AudioClip sodaCollectionSound;

    public void Collect()
    {
        AudioManager.Instance.PlaySoundEffect(sodaCollectionSound);
        Destroy(this.gameObject);
        OnSodaCollected?.Invoke(crabSodaItemData);
    }
}

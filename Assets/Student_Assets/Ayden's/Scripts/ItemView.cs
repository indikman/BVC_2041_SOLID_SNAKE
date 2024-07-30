using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemView : MonoBehaviour
{

    public event Action<int> ItemIncreasedEvent;
    public event Action<Sprite> ItemSpriteChangedEvent;
    public ItemSO item;
    public event Action<ItemSO> ObjectPickedUp;
    public void PickedUpEvent() => ObjectPickedUp?.Invoke(item);

    public Sprite _sprite;

    [SerializeField] private int despawnTime;

    public void UpdateCount(int ItemCount)
    {
        ItemCount++;
    }

    public void UpdateSpriteValue(Sprite sprite)
    {
        _sprite = sprite;
    }

    public void UpdateSprite(Sprite sprite)
    {
        ItemSpriteChangedEvent?.Invoke(sprite);
    }

    public void IncItemValue(int value)
    {
        ItemIncreasedEvent?.Invoke(value);
    }
    
}

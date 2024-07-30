using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemView : MonoBehaviour
{

    public event Action<int> ItemIncreasedEvent;
    public event Action<Sprite> SpriteChangedEvent;
    public ItemSO item;
    
    public void UpdateCount(int ItemCount)
    {
        
    }

    public void UpdateSprite(Sprite sprite)
    {
        SpriteChangedEvent?.Invoke(sprite);
    }

    public void IncItemValue(int value)
    {
        ItemIncreasedEvent?.Invoke(value);
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIView : MonoBehaviour
{
    private Sprite _sprite;
    
    public event Action<Sprite> SpriteChangedEvent;
    
    public Sprite Sprite
    {
        get => _sprite;
        set
        {
            _sprite = value;
            SpriteChangedEvent?.Invoke(_sprite);
        }
    }
    
}

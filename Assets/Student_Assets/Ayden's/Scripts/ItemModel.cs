using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemModel : MonoBehaviour
{

    private int _count;

    private string _name;

    private Sprite _sprite;

    public event Action<int> CountIncreasedEvent;

    public event Action<Sprite> SpriteChangedEvent;


    public int Count // relay message that count has changed
    {
        get => _count;
        set
        {
            _count = value;
            CountIncreasedEvent?.Invoke(_count);
        }
    }

    public Sprite Sprite // relay message that sprite has changed
    {
        get => _sprite;
        set
        {
            _sprite = value;
            SpriteChangedEvent?.Invoke(_sprite);
        }
    }
}

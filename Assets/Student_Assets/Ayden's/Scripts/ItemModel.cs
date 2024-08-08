using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemModel : MonoBehaviour
{

    private int _count = 1;

    private string _name;

    private Image _sprite;

    public event Action<int> CountIncreasedEvent;

    public event Action<Image> SpriteChangedEvent;


    public int Count // relay message that count has changed
    {
        get => _count;
        set
        {
            _count = value;
            CountIncreasedEvent?.Invoke(_count);
        }
    }

    public Image Sprite // relay message that sprite has changed
    {
        get => _sprite;
        set
        {
            _sprite = value;
            SpriteChangedEvent?.Invoke(_sprite);
        }
    }
}

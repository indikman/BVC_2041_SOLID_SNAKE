using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private ItemModel _model;
    private ItemView _view;


    public ItemController()
    {
        _view.ItemIncreasedEvent += IncItemValue;
        _model.SpriteChangedEvent += ChangeSpriteValue;
    }
    private void IncItemValue(int value)
    {
        _model.Count += value;
    }

    private void ChangeSpriteValue(Sprite sprite)
    {
        
    }
}

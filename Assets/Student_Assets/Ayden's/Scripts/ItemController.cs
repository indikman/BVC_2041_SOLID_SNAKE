using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private ItemModel _model;
    private ItemView _view;

    private void Start()
    {
        _model = FindObjectOfType<ItemModel>();
        _view = FindObjectOfType<ItemView>();
    }


    public ItemController()
    {
        _view.ItemIncreasedEvent += CountValueChanged;
        _view.ItemSpriteChangedEvent += SpriteValueChanged;
        _model.SpriteChangedEvent += ChangeSpriteValue;
        _model.CountIncreasedEvent += IncItemValue;
    }
    public void IncItemValue(int value)
    {
        _model.Count += value;
        Debug.Log("ModelValue");
    }

    public void ChangeSpriteValue(Sprite value)
    {
        _model.Sprite = value;
        Debug.Log("ModelSprite");
    }

    public void SpriteValueChanged(Sprite sprite)
    {
        _view.UpdateSpriteValue(sprite);
        Debug.Log("viewValue");
    }

    public void CountValueChanged(int value)
    {
        _view.IncItemValue(value);
        Debug.Log("viewSprite");
    }
    
    
}

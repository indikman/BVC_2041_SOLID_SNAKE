using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    private ItemModel _model;
    private ItemView _view;
    public List<Image> InventoryObjects { get; private set; } = new List<Image>();

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

    public void ChangeSpriteValue(Image value)
    {
        _model.Sprite = value;
        Debug.Log("ModelSprite");
    }

    public void SpriteValueChanged(Image sprite)
    {
        _view.UpdateSpriteValue(sprite);
        InventoryObjects.Add(sprite);
        Debug.Log("viewValue");
    }

    public void CountValueChanged(int value)
    {
        _view.IncItemValue(value);
        Debug.Log("viewSprite");
    }
    
    
}

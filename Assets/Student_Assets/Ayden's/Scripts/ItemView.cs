using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{

    public event Action<int> ItemIncreasedEvent;
    public event Action<Image> ItemSpriteChangedEvent;
    public ItemSO item;

    [SerializeField] private Image[] _inventorySprites;

    private ItemController _controller;

    private ItemModel _model;

    public void UpdateCount(int ItemCount)
    {
        ItemCount++;
    }

    private void Start()
    {
        
    }


    private void Awake()
    {
        _model = FindObjectOfType<ItemModel>();
        _inventorySprites = GetComponentsInChildren<Image>();
        _controller = FindObjectOfType<ItemController>();
        for (int i = 0; i < _inventorySprites.Length; i++)
        {
            _inventorySprites[i].enabled = false;
        }
    }

    public void UpdateSpriteValue(Image sprite)
    {
        for (int i = 0; i < _model.Count; i++ )
        {
            Debug.Log(sprite);
            _inventorySprites[i].enabled = true;
            //_inventorySprites[i] = sprite;
            _inventorySprites[i].sprite = sprite.sprite;

            //figure out recursively changing sprites 

        }
    }

    public void UpdateSprite(Image sprite)
    {
        ItemSpriteChangedEvent?.Invoke(sprite);
    }

    public void IncItemValue(int value)
    {
        ItemIncreasedEvent?.Invoke(value);
    }
    
}

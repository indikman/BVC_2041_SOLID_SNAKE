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
    public event Action<ItemSO> ObjectPickedUp;
    public void PickedUpEvent() => ObjectPickedUp?.Invoke(item);

    private Image[]  _sprite;

    [SerializeField] private Image[] _inventorySprites;

    private Inventory _inventory;

    [SerializeField] private int despawnTime;

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
        //_inventorySprites = GetComponentsInChildren<Image>();
        for (int i = 0; i < _inventorySprites.Length; i++)
        {
            _inventorySprites[i].enabled = false;
        }
    }

    public void UpdateSpriteValue(Image sprite)
    {
        for (int i = 0; i < _model.Count; i++ )
        {
            Debug.Log("inventory");
            _inventorySprites[i].enabled = true;
            _inventorySprites[i] = sprite;
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

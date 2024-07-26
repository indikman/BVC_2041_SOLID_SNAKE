using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ImageDataContainer : MonoBehaviour
{
    public ObjectSO ImageData = null;
    [SerializeField] private MenuItemSO _item;
    
    private void Awake()
    {
        //_item.MenuItemClicked += () => SendData();
    }

    public void UpdateImageData(ObjectSO data)
    {
        ImageData = data;
    }

    public void SendData()
    {
        _item.ItemSelected = ImageData;
    }
}


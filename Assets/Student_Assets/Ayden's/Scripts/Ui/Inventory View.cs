using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    private Image _image;
    private PickupEvent _pickupEvent;

    public void ImageChange(Image image)
    {
        Instantiate(image);
    }

    private void Start()
    {
        _pickupEvent = FindObjectOfType<PickupEvent>();
    }

    // add image specifed by item picked up event. when item picked up add image of said item
}

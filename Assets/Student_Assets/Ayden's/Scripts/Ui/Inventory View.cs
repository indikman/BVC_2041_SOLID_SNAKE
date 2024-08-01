    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    private Image _image;
    private PickupEvent _pickupEvent;
    // private Dictionary<int, Image> InventoryItems = new Dictionary<int, Image>();
    private Dictionary<Image, int> InventoryItems = new Dictionary<Image, int>(); 
    

    private void Inventory()
    {
        
    }

    public void ImageChange(Image image)
    {
        bool exists = InventoryItems.TryAdd(image, 1);
        if (exists)
        {
            Debug.Log(image);
            Instantiate(image, transform.parent);
        }
        else
        {
            Debug.Log("exists");
            return;
        }
    }

    
    /* bool exists = InventoryItems.TryAdd(_image, whatevervalue) //when we use TryAdd, it tries to add that exact key,value pair to the dictionary. Given that keys must be unique, it will fail if the _image, or the key, already exists. Note that it must be the same value as well. 
     * if exists == false
     *     do nothing 
     * else
     *    instantiate the image 
     */    
    
    private void Start()
    {
        _pickupEvent = FindObjectOfType<PickupEvent>();
    }

    // add image specifed by item picked up event. when item picked up add image of said item
    // create a dictionary for the sprite names, check when instantiating if names match any that already exist, if they do either stack or skip this particular item. increase the count as well
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    private List<ImageDataContainer> _items = new List<ImageDataContainer>();
    private CollectableObject[] _objects;
    [SerializeField] private Image _imagePrefab;
    [SerializeField] private MenuItemSO _selectedItem;
    private void Awake()
    {
        _objects = FindObjectsOfType<CollectableObject>();
        
        for (int i = 0; i < _objects.Length; i++) //very similar to what was done in TaskSO.cs
        {
            int index = i; 
            _objects[index].ObjectPickedUp += (pickup) => InitiateItem(pickup);;  //when an object is picked up, pass through the relevant data into this script
        }
    }

    private void InitiateItem(ObjectSO item)
    {
        //Debug.Log("Item get! " + item.ObjectName + "!");
        Image newIcon = Instantiate(_imagePrefab, Vector3.zero, quaternion.identity, this.transform); //make new child image in grid
        newIcon.sprite = item.InventoryIcon; //set the sprite to object sprite
        newIcon.GetComponentInChildren<TMP_Text>().text = item.ObjectName; //draw object name
        newIcon.GetComponent<ImageDataContainer>().UpdateImageData(item); //update item with proper SO data
        _items.Add(newIcon.GetComponent<ImageDataContainer>()); //add item object to inventory's list
    }

    public void DeleteItems()
    {
        for (int i = 0; i < _items.Count; i++) //an assumption is being made here - the trigger volume checks for the correct item upon interact, so if that goes through, then logically the player should have the right item.
        {
            if (_items[i].ImageData == _selectedItem.ItemSelected) //so if this is ever called/goes through properly, it should always be taking the correct item from the inventory - the current one being used.
            {
                _items[i].DestroySelf();
                _selectedItem.ItemSelected = null;
            }
        }
    }
}

using System;
using UnityEngine;

[System.Serializable]

public class Item_Grab : MonoBehaviour
{
    public string item;
    public string description;
    public Sprite icon;

    public event Action <bool> ItemGrabEvent; 

   
    private bool _itemObtained;
    public bool ItemObtained
    {
        get=> _itemObtained;
        set
        {
            _itemObtained = value;
            ItemGrabEvent?.Invoke(_itemObtained);
        }
    }

    public void FixedUpdate()
    {
        ItemGrabEvent += DestroyItem;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().gameObject.CompareTag("Player") && ItemObtained == false)
            ItemObtained = true;
    }

    public void DestroyItem(bool value)
    {
        if (value == true)
        {
            Debug.Log("Item Grabbed"); // This one serves no purpose, I just wanted to make sure the item was "obtained" (Destroyed porperly)

            Destroy(this.gameObject);
        }
    }
}
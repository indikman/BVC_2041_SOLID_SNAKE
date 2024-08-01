using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void PickUp();
public class PickupEvent : MonoBehaviour
{
    private EventManager _eventManager = new EventManager();
    private InventoryView _inventoryView;
    public MeshFilter _mesh;
    public ItemSO item;
    public MeshRenderer _renderer;
    public string _itemName;
    public Image _image;
    public Sprite _sprite;
    [SerializeField]private Transform _transform;

    public Action<ItemSO> ItemEvent;

    public void Start()
    {
        _mesh = GetComponent<MeshFilter>();
        _renderer = GetComponent<MeshRenderer>();
        _image = gameObject.GetComponent<Image>();
        _sprite = GetComponent<Sprite>();
        _sprite = item._sprite;
        _mesh.mesh = item.mesh;
        _renderer.material = item._material;
        _itemName = item.itemName;
        _image = item.itemSprite;

        gameObject.AddComponent<MeshCollider>();
        gameObject.GetComponent<MeshCollider>().convex = true;
        gameObject.GetComponent<MeshCollider>().isTrigger = true;
        _inventoryView = FindObjectOfType<InventoryView>();// set reference to inventory object 
        _eventManager.internalEvent += ReactionToItem;// subscribe to the event managers event
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            _eventManager.Run();// run the events
            Debug.Log("hit");
        }
    }

    public void ReactionToItem()
    {
        
        _image.sprite = _sprite;
       // Debug.Log(_sprite, _image);
        _inventoryView.ImageChange(_image); // change image
    }
    
    // parent images to the inventory screen, group images together by type/name 
}




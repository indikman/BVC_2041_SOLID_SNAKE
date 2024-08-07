using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public delegate void PickUpEvent();

public class PickableItem : MonoBehaviour
{
    private PickableEvent _pickableEvent = new PickableEvent();
    
    public MeshFilter meshFilter;

    [SerializeField] private PickableItemSo pickableSo;

    public MeshRenderer renderer;

    public Image _Image;

    public GameObject _gameObject;

    public TheInventory theInventory;

    public Inventory2 inventory2;

    [SerializeField] private AddObjectButton objectButton;

    [SerializeField]private TMP_Text _text;

    public ItemStats itemStats;

    public int count;
    

    private void Start()
    {
        
        meshFilter = gameObject.AddComponent<MeshFilter>();
        renderer = gameObject.AddComponent<MeshRenderer>();
        _Image = gameObject.AddComponent<Image>();
        theInventory = FindObjectOfType<TheInventory>();
        inventory2 = FindObjectOfType<Inventory2>();
        objectButton = pickableSo.ObjectButton;
        _Image.sprite = pickableSo.image.sprite;
        meshFilter.mesh = pickableSo.mesh;
        renderer.material = pickableSo.material;
        itemStats = pickableSo.ItemStats;
        _gameObject = pickableSo.gameObject;
        gameObject.AddComponent<MeshCollider>();
        gameObject.GetComponent<MeshCollider>().convex = true;
        gameObject.GetComponent<MeshCollider>().isTrigger = true;
        _pickableEvent.PickedEvent += ButtonInstance;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _pickableEvent.RunPickUp();
            Destroy(this.gameObject);
        }
    }

    public void ButtonInstance()
    {
        inventory2.CreateInventorySlot(objectButton);
        inventory2.AddItemStats(itemStats);
    }

    
    
    
}

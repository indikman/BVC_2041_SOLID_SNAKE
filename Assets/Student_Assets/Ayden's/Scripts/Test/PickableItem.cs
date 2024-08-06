using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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

    [SerializeField] private AddObjectButton objectButton;

    private void Start()
    {
        
        meshFilter = gameObject.AddComponent<MeshFilter>();
        renderer = gameObject.AddComponent<MeshRenderer>();
        _Image = gameObject.AddComponent<Image>();
        theInventory = FindObjectOfType<TheInventory>();
        //objectButton = gameObject.AddComponent<AddObjectButton>();
        objectButton.pickable = pickableSo;
        _Image.sprite = pickableSo.image.sprite;
        meshFilter.mesh = pickableSo.mesh;
        renderer.material = pickableSo.material;
        _gameObject = pickableSo.gameObject;
        gameObject.AddComponent<MeshCollider>();
        gameObject.GetComponent<MeshCollider>().convex = true;
        gameObject.GetComponent<MeshCollider>().isTrigger = true;
        _pickableEvent.PickedEvent += CreateInventorySlot;
        _pickableEvent.PickedEvent += CreateSo;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _pickableEvent.RunPickUp();
            Destroy(this.gameObject);
        }
    }

    public void CreateSo()
    {
        objectButton.GetSo(pickableSo);
    }

    public void CreateInventorySlot()
    {
        Instantiate(objectButton,
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,
                gameObject.transform.position.z), Quaternion.identity, theInventory.transform);
    }
    
    
}

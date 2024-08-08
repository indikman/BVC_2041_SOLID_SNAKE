using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private EventManager2 _eventManager2;
    public ItemSO itemSo;
    private ItemInventory _inventory;
    private MeshFilter _meshFilter;
    private Renderer _renderer;

    private void Start()
    {
        _inventory = FindObjectOfType<ItemInventory>();
        _meshFilter = gameObject.AddComponent<MeshFilter>();
        _renderer = gameObject.AddComponent<MeshRenderer>();
        _meshFilter.mesh = itemSo.mesh;
        _renderer.material = itemSo._material;
        _eventManager2 = FindObjectOfType<EventManager2>();
        gameObject.AddComponent<MeshCollider>();
        gameObject.GetComponent<MeshCollider>().convex = true;
        gameObject.GetComponent<MeshCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnItemPickedUp();
            Destroy(this.gameObject);
        }
    }
    

    void OnItemPickedUp()
    {
        _inventory._itemSo = itemSo;
        _eventManager2.RunEvent();
    }
}

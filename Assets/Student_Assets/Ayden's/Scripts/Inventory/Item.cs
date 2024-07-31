using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public MeshFilter _mesh;
    public ItemSO item;
    public MeshRenderer _renderer;
    public string _itemName;
    
    
    private void Start()
    {
        _mesh = GetComponent<MeshFilter>();
        _renderer = GetComponent<MeshRenderer>();
        _mesh.mesh = item.mesh;
        _renderer.material = item._material;
        _itemName = item.itemName;
        gameObject.AddComponent<MeshCollider>();
        gameObject.GetComponent<MeshCollider>().convex = true;
        gameObject.GetComponent<MeshCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Debug.Log("hit");
        }
    }
}

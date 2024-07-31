using System;
using System.Collections;
using System.Collections.Generic;
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

    }
}

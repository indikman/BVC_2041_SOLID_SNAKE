using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Itdsem : MonoBehaviour
{
    public MeshFilter _mesh;
    public ItemSO item;
    public MeshRenderer _renderer;
    public string _itemName;
    public Image _image;
    public Sprite _sprite;
    public EventManager _eventManager;

    public Action<ItemSO> ItemEvent;
    
    
    private void Start()
    {
        _mesh = GetComponent<MeshFilter>();
        _renderer = GetComponent<MeshRenderer>();
        _image = gameObject.GetComponent<Image>();
        _sprite = GetComponent<Sprite>();
        _sprite = item._sprite;
        _mesh.mesh = item.mesh;
        _renderer.material = item._material;
        _image = item.itemSprite;

        gameObject.AddComponent<MeshCollider>();
        gameObject.GetComponent<MeshCollider>().convex = true;
        gameObject.GetComponent<MeshCollider>().isTrigger = true;
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
}

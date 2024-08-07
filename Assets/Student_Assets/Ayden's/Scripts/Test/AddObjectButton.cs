using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AddObjectButton : MonoBehaviour
{
    public PickableItemSo pickable;
    public Image _image;
    public Button button;
    [SerializeField, TextArea] private string description;
    public GameObject _gameobject;
    private Transform _transform;
    private int _count;

    private Sprite _sprite;
    //private Text _text;
    
    public Dictionary<GameObject, int> PlayerItems = new Dictionary<GameObject, int>();


    private void Start()
    {
        _image = gameObject.AddComponent<Image>();
        button = gameObject.AddComponent<Button>();
        _transform = FindObjectOfType<hands>().transform;
        _sprite = GetComponent<Sprite>();
        
        
        
        
        
        _sprite = pickable.sprite;
        _image.sprite = _sprite;
        description = pickable.ItemDescription;
        _gameobject = pickable.gameObject;
        button.onClick.AddListener(ItemSet);
        //_count = 1;

    }

    public void GetSo(PickableItemSo pickableItemSo)
    {
        pickable = pickableItemSo;
    }

    void ItemSet()
    {
        _gameobject = pickable.gameObject;
        ItemChange(_gameobject);
    }


    public void ItemChange(GameObject _gameObject)
    {
        bool exists = PlayerItems.TryAdd(_gameObject, 1);// use the dictionary to check if gameobject already exists
        if (exists) // does only once per item
        {
            Debug.Log("Instantiate");
            Instantiate(_gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, _transform);
            //_count--;

        }
        else
        {
            Debug.Log("PlayerItemExists");
            //_count++;
            return;

        }

    }
    

    void OnClick()
    {
        ItemChange(_gameobject);
    }

    public void Dequip()
    {
        //_count--;
    }

    public void OnEnable()
    {
        
    }
}

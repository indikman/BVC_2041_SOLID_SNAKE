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
    private ItemType _itemType;
    private InteractableItem _item;
    

    private Sprite _sprite;
    //private Text _text;
    
    public Dictionary<Enum, GameObject> PlayerItems = new Dictionary<Enum, GameObject>();
    
    private void Start()
    {

        _image = gameObject.AddComponent<Image>();
        button = gameObject.AddComponent<Button>();
        _transform = FindObjectOfType<hands>().transform;
        _sprite = GetComponent<Sprite>();
        _itemType = pickable.itemType;
        
        
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

        _item = FindAnyObjectByType<InteractableItem>();
        bool exists = PlayerItems.TryAdd(_itemType, _gameObject);// use the dictionary to check if gameobject already exists
        if (exists) // does only once per item  
        {
            if (_item == null)
            {
                Debug.Log("Instantiate");
                Instantiate(_gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, _transform);
                //_count--;

            }

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
        if (_itemType == ItemType.Key)
        {
            PlayerItems.Remove(ItemType.Key);
        }

        if (_itemType == ItemType.Donut)
        {
            PlayerItems.Remove(ItemType.Donut);
        }
        //_count--;
        Debug.Log("fuck");
    }

    public void OnEnable()
    {
        
    }
}

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
    public ItemType _itemType;
    private InteractableItem _item;
    public TMP_Text text;
    

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
        text = FindAnyObjectByType<TMP_Text>();
        Instantiate(text, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, _transform);
        
        
        _sprite = pickable.sprite;
        _image.sprite = _sprite;
        description = pickable.ItemDescription;
        _gameobject = pickable.gameObject;
        button.onClick.AddListener(ItemSet);
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

            if (_item == null)
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

    
    public void Dequip(ItemType itemType)
    {
        _itemType = itemType;
        PlayerItems.Remove(_itemType);
        //_count--;
        Debug.Log("fuck");
    }

    public void OnEnable()
    {
        
    }
}

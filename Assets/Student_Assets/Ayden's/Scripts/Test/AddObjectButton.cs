using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddObjectButton : MonoBehaviour
{
    public PickableItemSo pickable;
    public Image _image;
    public Button button;
    [SerializeField, TextArea] private string description;
    public GameObject _gameobject;
    [SerializeField]private Transform _transform;
    
    private Dictionary<GameObject, int> PlayerItems = new Dictionary<GameObject, int>();


    private void Start()
    {
        _image = gameObject.AddComponent<Image>();
        button = gameObject.AddComponent<Button>();
        _image = pickable.image;
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
        ItemChange(_gameobject);
    }


    public void ItemChange(GameObject _gameObject)
    {
        bool exists = PlayerItems.TryAdd(_gameObject, 1);// use the dictionary to check if gameobject already exists
        if (exists) // does only once per item
        {
            Debug.Log("Instantiate");
            Instantiate(_gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, _transform);
            

        }
        else
        {
            Debug.Log("PlayerItemExists");
            return;
        }

    }

    void OnClick()
    {
        ItemChange(_gameobject);
    }


}

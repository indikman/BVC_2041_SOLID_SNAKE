using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryButton : MonoBehaviour
{
    private Image image;
    private GameObject _GameObject;
    public ItemSO _itemSo;
    private Button _button;
    private Transform _transform;

    private void Awake()
    {
        _button = GetComponent<Button>();
        image = GetComponent<Image>();
        _transform = FindObjectOfType<hands>().transform;
        image.sprite = _itemSo._sprite;
        _GameObject = _itemSo._gameObject;
    }

    private void Start()
    {
        _button.onClick.AddListener(ItemSet);
    }

    private void ItemSet()
    {
        Debug.Log(_GameObject);
        Instantiate(_GameObject, new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z), Quaternion.identity, _transform);
    }
}

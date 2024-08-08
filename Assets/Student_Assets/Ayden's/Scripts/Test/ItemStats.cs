using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemStats : MonoBehaviour
{
    public PickableItemSo _itemSo;
    public TMP_Text Text;
    public TMP_Text countText;
    [SerializeField]private int count;
    public bool enabled;

    private void Start()
    {
        Text = GetComponent<TMP_Text>();
        //countText = GetComponent<TMP_Text>();
        
        Text.SetText(_itemSo.Description);
    }

    private void Awake()
    {
        
    }   

    public void IncreaseCount(int _count)
    {
        Debug.Log(_count);
        count = _count;
        countText.SetText(count.ToString());
    }
}



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
    private int count;
    public Aydens changeState;
    public bool enabled;

    private void Start()
    {
        Text = GetComponent<TMP_Text>();
        //countText = GetComponent<TMP_Text>();
        
        Text.SetText(_itemSo.Description);
    }

    public void IncreaseCount(int _count)
    {
        count = count + _count;
        var number = count + _count;
        var amount = number.ToString();
        countText.SetText(amount);
    }

    private void FixedUpdate()
    {
        if (count != null)
        {
            
        }
    }
}



using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TheInventory : MonoBehaviour
{
    public TMP_Text text;
    public int count;
    [field: SerializeField, TextArea] public string ItemDescription { get; private set; }


    public void IncrementCount(int _count)
    {   
        var amount = _count.ToString();
        text.SetText(amount);
    }

    public void CreateInfo()
    {
        
    }

    private void Start()
    {
        
    }
}

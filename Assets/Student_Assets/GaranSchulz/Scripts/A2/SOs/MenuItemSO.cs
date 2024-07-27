using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

[CreateAssetMenu(fileName = "MenuItemSO", menuName = "SOs/Garan/MenuItemSO", order = 0)]
public class MenuItemSO : ScriptableObject
{
    public event Action MenuItemClicked;
    public ObjectSO ItemSelected;
    
    //this SO essentially handles what the current selected item is
    public void ClickEvent() => MenuItemClicked?.Invoke(); //this event switches what item is selected when you click on one

    private void OnEnable()
    {
        ItemSelected = null;
    }
    
}

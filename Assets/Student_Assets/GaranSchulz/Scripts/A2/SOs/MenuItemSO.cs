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

    public void ClickEvent() => MenuItemClicked?.Invoke();
}

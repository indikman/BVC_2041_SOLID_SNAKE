using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

[CreateAssetMenu(fileName = "MenuControlChannelSO", menuName = "SO/Inputs/MenuInputSO", order = 2)]
public class MenuInteractionSO : ScriptableObject
{
    public event Action OnMenuOpen, OnMenuClose, OnItemSelected;
    public event Action<float> OnMenuScroll;
    
    public void HandleMenuOpen() => OnMenuOpen?.Invoke();
    public void HandleMenuClose() => OnMenuClose?.Invoke();
    public void HandleItemSelected() => OnItemSelected?.Invoke();
    public void HandleMenuScroll(float scrollDir) => OnMenuScroll?.Invoke(scrollDir);
}

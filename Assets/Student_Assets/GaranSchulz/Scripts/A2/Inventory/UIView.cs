using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIView : MonoBehaviour
{
    [SerializeField] private Image _descBG;
    [SerializeField] private TMP_Text _descText;
    [SerializeField] private Button _equipButton;
    [SerializeField] private MenuItemSO _itemCall;

    private void Awake()
    {
        _itemCall.MenuItemClicked += () => UpdateTextBox();
    }

    private void UpdateTextBox()
    {
        _descBG.gameObject.SetActive(true);
        _equipButton.gameObject.SetActive(true);
        //_descText.gameObject.SetActive(true);
        Invoke("UpdateTextBoxDelay", 0.01f); //gross hack but ensures proper item description is loaded
    }

    private void UpdateTextBoxDelay()
    {
        _descText.text = _itemCall.ItemSelected.ObjectDescription;
    }

    public void HideTextBox()
    {
        _descBG.gameObject.SetActive(false);
        _equipButton.gameObject.SetActive(false);
    }
}

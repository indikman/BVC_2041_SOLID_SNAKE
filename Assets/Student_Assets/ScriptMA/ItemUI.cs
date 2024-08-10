using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemUI : MonoBehaviour
{
    public Image Image;
    public TextMeshProUGUI Name;


    public void SetItems(InSO item) 
    {
       Image.sprite = item.icon;
      Name.text = item.itemName;


    }

}

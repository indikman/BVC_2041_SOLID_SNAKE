using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemButton : MonoBehaviour
{

	[SerializeField] private Image itemImage;
	[SerializeField] private TMP_Text itemNameText;

	public void SetButton(ItemSO ItemData)
	{
	itemImage.sprite = ItemData.Icon;
	itemNameText.text = ItemData.ItemName;
	
	}
}

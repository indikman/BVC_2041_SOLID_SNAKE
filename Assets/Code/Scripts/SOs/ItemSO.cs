using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "SOs/Item")]

public class ItemSO : ScriptableObject
{
	[Header("Base Information")]
 	public int id;
   	public string ItemName;
  	public Sprite Icon;
	public string Description;
	
}

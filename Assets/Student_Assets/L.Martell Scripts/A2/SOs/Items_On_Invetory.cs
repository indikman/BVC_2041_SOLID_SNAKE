
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemAccess", menuName = "A2/ItemsOnScene", order = 3)]
public class Items_On_Inventory : ScriptableObject
{
    public List<Item_Grab> itemList = new List<Item_Grab>();
}
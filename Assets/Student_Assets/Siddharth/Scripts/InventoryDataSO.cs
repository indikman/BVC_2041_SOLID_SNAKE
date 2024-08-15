using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Data/Item", fileName = "Item")]
public class InventoryDataSO : ScriptableObject
{
    public string id; //To get the reference easily 
    public string itemName; //To see the item Name 
    public string itemDescription; //To see the description of the item
    public Sprite icon; //The image or the reference of the game object 
    public GameObject prefab; //The Model of the item or the prefab itself
    
}

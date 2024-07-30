using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "SOs/UI/Items/ItemSO", order=1)]
public class ItemSO : ScriptableObject
{

    public string itemName;

    public Sprite itemSprite;

    public GameObject itemObject;

    void Start()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSO : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite itemIcon;
    public GameObject itemPrefab;
    public abstract void Use();
}


[CreateAssetMenu(fileName = "ItemKey", menuName = "SOs/Item Key")]
public class ItemKey : ItemSO
{
    public override void Use()
    {
        Debug.Log("Using item");
    }
}

[CreateAssetMenu(fileName = "ItemSoap", menuName = "SOs/Item Soap")]
public class ItemSoap : ItemSO
{
    public override void Use()
    {
        Debug.Log("Using item");
    }
}
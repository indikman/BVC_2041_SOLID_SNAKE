using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectSO", menuName = "SOs/a.crunkhorn654/SO", order = 0)]
public class PickupSO : ScriptableObject
{
    public GameObject itemPrefab;
    public string itemName;
    public Sprite itemIcon;
    public Mesh itemModel;
    public string itemDescription;


    public void Interact()
    {

    }
}

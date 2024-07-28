using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;
    [SerializeField] private GameObject model;

    public string ItemName => itemName;
    public string Description => description;
    public Sprite Icon => icon;
    public GameObject Model => model;
}


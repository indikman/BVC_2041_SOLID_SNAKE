using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class InSO : ScriptableObject
{

    public string itemName;
    public string description;
    public Sprite icon;
    public GameObject Model;

    public UnityAction OnInteract; 
}

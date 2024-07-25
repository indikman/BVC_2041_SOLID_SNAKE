using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIView : MonoBehaviour
{
    private CollectableObject[] _objects;
    [SerializeField] private Image _imagePrefab;
    private void Awake()
    {
        _objects = FindObjectsOfType<CollectableObject>();
        
        for (int i = 0; i < _objects.Length; i++) //very similar to what was done in TaskSO.cs
        {
            int index = i; 
            _objects[index].ObjectPickedUp += (pickup) => CommunicateWithUI(pickup);;  //when an object is picked up, pass through the relevant data into this script
        }
    }

    private void CommunicateWithUI(ObjectSO item)
    {
        Debug.Log("Item get! " + item.ObjectName + "!");
        Image newIcon = Instantiate(_imagePrefab, Vector3.zero, quaternion.identity, this.transform); //make new child image in grid
        newIcon.sprite = item.InventoryIcon;
        newIcon.GetComponentInChildren<TMP_Text>().text = item.ObjectName; //for later
    }
}

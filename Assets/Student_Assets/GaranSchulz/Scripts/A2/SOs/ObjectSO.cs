using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectSO", menuName = "SOs/Garan/ObjectSO", order = 0)]
public class ObjectSO : ScriptableObject, IStrategy
{
    [field: SerializeField] public string ObjectName { get; private set; }
    [field: SerializeField] public Sprite InventoryIcon { get; private set; }
    [field: SerializeField] public Mesh WorldModel { get; private set; }
    [field: SerializeField] public Material ModelMaterial { get; private set; }
    [field: SerializeField] public string ObjectDescription { get; private set; }
    
    public void Interact()
    {
        Debug.Log("Interacting with " + ObjectName);
    }
}

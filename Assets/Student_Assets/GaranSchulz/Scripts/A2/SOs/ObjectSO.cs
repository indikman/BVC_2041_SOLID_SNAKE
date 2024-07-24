using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectSO", menuName = "SOs/Garan/ObjectSO", order = 0)]
public class ObjectSO : ScriptableObject
{
    [field: SerializeField] public string ObjectName { get; private set; }
    [field: SerializeField] public Sprite InventoryIcon { get; private set; }
    [field: SerializeField] public MeshRenderer WorldModel { get; private set; }
    public bool IsPickedUp;
    public event Action<string> ObjectPickedUp;
    public void PickupEvent() => ObjectPickedUp?.Invoke(ObjectName);
}

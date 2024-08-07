using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PickableItem", menuName = "SOs/UI/Items/PickableItemSO", order=1)]
public class PickableItemSo : ScriptableObject
{
    public Image image;

    public Mesh mesh;

    public Material material;

    public GameObject gameObject;

    public MeshCollider collider;

    public string name;

    public AddObjectButton ObjectButton;

    public Sprite sprite;
    
    [field: SerializeField, TextArea] public string ItemDescription { get; private set; }

    public ItemType itemType;
}
public enum ItemType
{
    Key, Donut
}

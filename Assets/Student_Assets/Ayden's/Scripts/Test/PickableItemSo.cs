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

    public string Description;

    public ItemType itemType;

    public ItemStats ItemStats;
}


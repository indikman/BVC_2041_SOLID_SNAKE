using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "SOs/UI/Items/ItemSO", order=1)]
public class ItemSO : ScriptableObject
{

    public Image itemSprite;

    public Sprite _sprite;
    
    public Mesh mesh;

    public Material _material;

    public GameObject _gameObject;

    public MeshCollider collider;
    
    [field: SerializeField] public string ItemName { get; private set; }
    [field: SerializeField] public ItemEnum ItemType { get; private set; }
    [field: SerializeField, TextArea] public string ItemDescription { get; private set; }

}

public enum ItemEnum
{
    Key, Weapon,Useless
}

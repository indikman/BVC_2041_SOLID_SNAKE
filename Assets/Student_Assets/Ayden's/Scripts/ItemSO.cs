using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "SOs/UI/Items/ItemSO", order=1)]
public class ItemSO : ScriptableObject
{

    public string itemName;

    public Image itemSprite;

    public Sprite _sprite;
    
    public Mesh mesh;

    public Material _material;

    public MeshCollider collider;
    void Start()
    {
        
    }
}

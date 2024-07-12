using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "SOs/Items/ItemSO", order = 1)]
public class ItemSO : ScriptableObject
{
    [field: SerializeField]
    public string name;

    [field: SerializeField]
    public string description;

    [field: SerializeField]
    public Sprite sprite;
}

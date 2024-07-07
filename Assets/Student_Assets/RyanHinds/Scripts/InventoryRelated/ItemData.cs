using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create Item", menuName = "Ryan/SO/Create/Item", order = 0)]
public class ItemData : ScriptableObject
{
    public string DisplayName;
    public Sprite Icon;
}

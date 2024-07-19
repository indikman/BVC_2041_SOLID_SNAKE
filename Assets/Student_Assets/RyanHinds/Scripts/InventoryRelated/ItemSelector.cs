using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelector : MonoBehaviour
{
    public event Action<ItemData> OnItemSelected;
    public event Action<ItemData> OnItemChosen;
    
    
}

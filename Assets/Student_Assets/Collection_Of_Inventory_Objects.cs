using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Accesible_Inventory_Object", menuName = "Siena SO's/Assign a storable object", order = 2)]
public class Collection_Of_Inventory_Objects : ScriptableObject
{
   public List<Individual_Interactable> interactbleObject = new List<Individual_Interactable>();
}

//Type Mismatch in a scriptable object usually means you're trying to reference a scene object. Asset-level objects cannot reference scene-level objects.
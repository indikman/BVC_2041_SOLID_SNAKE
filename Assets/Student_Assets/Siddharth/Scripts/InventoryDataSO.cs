using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Item Data/Item", fileName = "Item")]
public class InventoryDataSO : ScriptableObject
{
    public bool isActive;
    public string id; //To get the reference easily 
    public string itemName; //To see the item Name 
    public string itemDescription; //To see the description of the item
    public Sprite icon; //The image or the reference of the game object 
    public GameObject prefab; //The Model of the item or the prefab itself

    public UnityEvent OnItemUse;
    public List<InventoryDataSO> rewards;

    public InventoryManager inventoryManager
    {
        get; set;
    }

    public void OnEnable()
    {
        isActive = false;
    }

    public void Use(Interactable interactableObject)
    {
        if(isActive)
        {
            interactableObject.ItemTrigger();
            foreach(InventoryDataSO item in rewards)
            {
                inventoryManager.AddItem(item);
            }
        }
    }
}

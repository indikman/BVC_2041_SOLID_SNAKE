using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<InSO> items = new List<InSO>();
    public ItemUI ItemUI;
    public GameObject InventoryGrid;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddItem(InSO item)
    {

        items.Add(item);
        DisplayItem(item);

    }
    public void RemoveItem(InSO item)
    {
        items.Remove(item);
        foreach (Transform child in InventoryGrid.transform)
        {

            if (child.gameObject.GetComponent<ItemUI>().Name.text == item.name)
            {
                Debug.Log("Destroy");

                Destroy(child.gameObject);
            }
        }
    }
    public void DisplayItem(InSO item)
    {
        ItemUI newItemUI = Instantiate(ItemUI, InventoryGrid.transform);
        newItemUI.SetItems(item);
    }
}
    



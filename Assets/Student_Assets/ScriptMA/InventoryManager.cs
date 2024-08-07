using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<InSO> items = new List<InSO>();
    public GameObject ItemUI;
    public GameObject InventoryGrid;

    // Start is called before the first frame update
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
    public void RemoveItem()
    {

    }
   public void DisplayItem(InSO item)
    {
     GameObject newItemUI =  Instantiate(ItemUI, InventoryGrid.transform);
        newItemUI.transform.GetChild(1).GetComponent<Image>().sprite = item.icon;
        newItemUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.itemName;

    }

}

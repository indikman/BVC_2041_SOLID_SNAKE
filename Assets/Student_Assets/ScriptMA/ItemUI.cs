using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemUI : MonoBehaviour,IInteractable
{
    public Image Image;
    public TextMeshProUGUI Name;
    public string ItemName
    {
        get
        {
            return Name.text;
        }
    
    }
  
    public void Interact()
    {
        IInteractable interactable = this.gameObject.GetComponent<IInteractable>();
        if (interactable != null)
        {
            InventoryManager.Instance.SelectItem(interactable);
        }
       
    }
    public void SetItems(InSO item)
    {
        Image.sprite = item.icon;
        Name.text = item.itemName;
    }
}
    



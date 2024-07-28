using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemSelector : MonoBehaviour
{

    public event Action<ItemSO> OnItemLoad;
    public event Action<ItemSO> OnItemSelected;
    public event Action<ItemSO> OnItemChosen;
    [SerializeField] ItemSO[] allItems;
    private ItemSO _selectedItem;
    private ItemSO _chosenItem;

    private void LoadItems()
    {
        foreach (var itemData in allItems)
        {
            OnItemLoad?.Invoke(itemData);
        }
    }

    //exec on item button press
    public void SelectItem(ItemSO itemData)
    {
        _selectedItem = itemData;
        OnItemSelected?.Invoke(_selectedItem);

    }

    // Start is called before the first frame update
    void Start()
    {
        LoadItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory2 : MonoBehaviour
{
    public Dictionary<AddObjectButton, int> PlayerItems = new Dictionary<AddObjectButton, int>();

    public Dictionary<TMP_Text, int> TextDic = new Dictionary<TMP_Text, int>();

    private AddObjectButton objectButton;

    private TheInventory theInventory;

    private TMP_Text text;

    public int itemCount;
    public void CreateInventorySlot(AddObjectButton _objectButton )
    {
        bool exists = PlayerItems.TryAdd(_objectButton, 1);
        if (exists)
        {
            objectButton = _objectButton;
            Debug.Log("Fucking doesn't exists");
            Instantiate(_objectButton,
                new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,
                    gameObject.transform.position.z), Quaternion.identity, theInventory.transform);
        }
        else
        {
            Debug.Log("Fucking exists");
            return;
        }
    }
    

    private void Start()
    {
        theInventory = FindObjectOfType<TheInventory>();
        
    }
}

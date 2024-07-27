using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSO item;

    public event Action<ItemSO> OnCollectedItem;

    private void Awake()
    {
        Debug.Log("Hi");
        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
        OnCollectedItem += playerInventory.AddItem;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Item: " + item.name);
            Destroy(this.gameObject);
            OnCollectedItem?.Invoke(item);
        }
    }
}

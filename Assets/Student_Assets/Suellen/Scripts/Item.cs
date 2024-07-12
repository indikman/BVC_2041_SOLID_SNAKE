using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSO item;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Item: " + item.name);
        Destroy(this);
    }
}

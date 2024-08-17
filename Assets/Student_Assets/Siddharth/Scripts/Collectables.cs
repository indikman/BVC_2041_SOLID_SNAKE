using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
public class Collectables : MonoBehaviour
{
    public UnityEvent itemCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Item collected.");
            itemCollected.Invoke();
            Destroy(gameObject);
        }
    }
}

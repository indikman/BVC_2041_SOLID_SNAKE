using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
public class Collectables : MonoBehaviour
{

    public UnityEvent keyCollected;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            keyCollected.Invoke();
            Debug.Log("Sdbkabsdkbasdkbaskdbk");
            //Destroy(gameObject);
        }
    }
    public void KeyCollect()
    {
        Debug.Log("Key is Mine");
    }
}

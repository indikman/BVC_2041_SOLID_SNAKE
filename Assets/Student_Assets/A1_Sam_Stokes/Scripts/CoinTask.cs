using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTask : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        TaskManager taskManager = other.GetComponent<TaskManager>();

        if (taskManager != null )
        {
            taskManager.CoinsCollected();
            gameObject.SetActive(false);
        }
    }
}

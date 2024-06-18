using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single_Task : MonoBehaviour
{
    public TaskManager taskManager;
    private bool taskCompleted = false; //This bool is to avoid the "if" statement in line 12 from running a second time upon collision

    void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<Collider>().gameObject.CompareTag("Player") && taskCompleted == false)
        {
            taskManager.playerDoneTask = true; //This bool value is called to "taskManager" now
            taskCompleted = true;
        }
    }
}

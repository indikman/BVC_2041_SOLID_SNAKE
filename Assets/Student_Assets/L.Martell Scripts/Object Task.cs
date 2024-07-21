using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTask : MonoBehaviour
{
   [SerializeField]
   TaskManager _taskManager;
   
   public bool _objectTask = false;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<Collider>().gameObject.CompareTag("Player") && _objectTask == false)
        {
            _taskManager.objectTaskLink = true; // "objectTaskLink" is the one used in the Task Manager, this is the script connecting the single tasks, to the task list.
            _objectTask = true;
        }
    }
}

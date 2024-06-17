using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TasksEventManager : MonoBehaviour
{
    public delegate void CompletedTask();
    public static event CompletedTask taskCompleted;
    public BoxCollider [] taskBoxColliders;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<Collider>().gameObject.CompareTag("Player"))
            if(taskCompleted != null)
                taskCompleted(); 
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private TaskSO taskObject;
    public bool Interacted;

    private void OnTriggerEnter(Collider other)
    {
        if (taskObject.TaskCompleted)
            return;

        if(taskObject.TaskType == TaskType.Move && other.CompareTag("Player"))
        {
            taskObject.CompleteTask();
            
        }
        else if(taskObject.TaskType == TaskType.Interact)
        {
            if(Interacted)
            {
                taskObject.CompleteTask();
            }
        }
    }
    public void TaskActivate()
    {
        taskObject.TaskActive();
        Debug.Log("Activate Task");
    }
}

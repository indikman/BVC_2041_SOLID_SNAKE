using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUpdater : MonoBehaviour
{
    [Header("Task")]
    [SerializeField] private TaskSO customTask;

    /// <summary>
    /// Timer logic has been removed and replaced with a simpler implementation
    /// A player could now watch for as long as they want... Or just run past!
    /// This gives the "Collision" use as seen in the doorway, and also the "Examination" use as seen by the fishtank.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (customTask.TaskCompletionStatus == true) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("Task In Progress!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (customTask.TaskCompletionStatus == true) return;

        if (other.CompareTag("Player"))
        {
            customTask.CompleteTask();
            Debug.Log("Task should be completed... If not scream");
        }
    }

    //void "Advancetonextarea" removed, didn't seem important
}
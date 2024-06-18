using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Individual_Task : MonoBehaviour
{
    [SerializeField] 
    protected TasksNeedToBeCompleted taskNeedToBeCompleted; //Grabbing the Scriptable Object Reference from Assets
    [SerializeField] 
    private AudioSource taskFinishedSFX; //Sound Effect to play when the task is finished

    private bool taskIsDone = false;
    private bool taskFinishedOnce = false;

    void OnEnable()
    {
        TasksNeedToBeCompleted.taskCompleted += PlayCompletionSound; //Attempting to subscribe to the event from the Scriptable Object called "TasksNeedToBeCompleted"
    }

    void OnDisable()
    {
        TasksNeedToBeCompleted.taskCompleted -= PlayCompletionSound; //Attempting to unsubscribe to the event from the Scriptable Object called "TasksNeedToBeCompleted"
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<Collider>().gameObject.CompareTag("Player") && taskFinishedOnce == false)
        {
            taskIsDone = true;
            taskFinishedOnce = true;
            taskNeedToBeCompleted.taskIsOver = taskFinishedOnce; //Attempting to assign a public bool value in the Scriptable Object called "TasksNeedToBeCompleted" from one in this script
            PlayCompletionSound();
        }
    }

    void PlayCompletionSound()
    {
        if(taskIsDone == true && taskFinishedOnce != false)
           taskFinishedSFX.Play(); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public UnityEvent TaskListComplete; 
    public IndividualTask individualTask;
    public CollectionOfTasks collectionOfTasks;
    public TMP_Text textForTask;

    [HideInInspector]
    public bool playerDoneTask = false; //This bool value is called and influenced by the "Single_Task" script

    [HideInInspector]
    public bool playerHasCompletedTask = false; 
    //"playerHasCompletedTask" is called and will pass its value to scripts that move doors based on the "TaskListComplete" event
    //These scripts will be "CounterTop_OpenDoor", "Open_Door" and "Close_Door"
    
    public AudioSource taskCompletionSound;

    private void Update()
    {
        foreach(var task in collectionOfTasks.task) //Going through every variable named "task" in the "collectionOfTasks" list
        {
            individualTask.isTaskComplete = playerDoneTask;

            if(playerDoneTask == true)
            {
                playerHasCompletedTask = true;
                TaskListComplete?.Invoke();
                playerDoneTask = false; //Resetting the bool to false because of an issue with the sound effect being buggy.
                individualTask.isTaskComplete = playerDoneTask;
                textForTask.text = string.Format("<s>" + textForTask.text + "<s>"); //Making the "textForTask" have a cross out from the UI Canvas
            }
        }
    }

    public void UpdateTasks()
    {
        taskCompletionSound.Play();
    }
}

[System.Serializable]
public class IndividualTask
{
    public string taskName;
    public bool isTaskComplete;
}
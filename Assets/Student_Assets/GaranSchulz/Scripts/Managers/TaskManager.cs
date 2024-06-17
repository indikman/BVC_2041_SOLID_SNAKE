using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private TaskSO[] tasks;
    [SerializeField] private TextMeshProUGUI[] canvasTasks;
    public UnityEvent CompletedAllTasks;
    private int _tasksComplete = 0;
    private AudioSource _sfx;
    private void Awake()
    {
        _sfx = GetComponent<AudioSource>();
        for (int i = 0; i < tasks.Length; i++)
        {
            int index = i; //Weird C# thing, apparently - this has to be cached locally so that the pointer doesn't keep pointing to the same place in memory(?)
            tasks[index].Completed = false; //this has to be done so that the scriptableobjects don't stay completed when the scene is closed
            tasks[index].IsComplete += () => AssignTaskComplete(index); //Subscribe to event to check if task at specific array index is completed
        }
    }

    public void AssignTaskComplete(int number)
    {
        if (tasks[number].Completed) //if you've already done this task, don't need to do anything else
            return;
        tasks[number].Completed = true;
        _tasksComplete++; 
        _sfx.Play();
        //Debug.Log("tasks complete is " + _tasksComplete);
        canvasTasks[number].color = new Color(0f, 1.0f, 0f); //set task colour to green
        if (_tasksComplete == tasks.Length)
        {
            Debug.Log("All tasks complete!");
        }
    }
    public void AllTasksComplete() => CompletedAllTasks.Invoke();
}

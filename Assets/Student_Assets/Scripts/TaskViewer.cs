using System;
using System.Collections.Generic;
using Microlight.MicroAudio;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class TaskViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text tasksText;
    [SerializeField] private TMP_Text description;
    [SerializeField] private List<TaskSO> tasks;
    [SerializeField] public AudioClip completesfx;
    private int _taskcompletionCounter = 0;
    [FormerlySerializedAs("OnAreaTasksComplete")] public UnityEvent onAreaTasksComplete;
    

    /// <summary>
    /// Of all the implementations based off Ryan's help over Discord (Bless), this one is the least changed
    /// It's been changed to hook into my TaskSO
    ///
    /// On enabled, it updates our TMP to include the name of every task.
    /// On update, it checks if our "taskcompletionCounter" equals this amount of tasks, and if so, calls that the area is done!
    /// This can be used to say, open the back door and "complete" the level.
    ///
    /// On the completion of a task, it will strikethrough the name to show completion.
    /// and count up the taskcompletionCounter.
    ///
    /// Ryan's implementation had "Addnewtask"... isn't really used but it's smart to have.
    /// </summary>
    /// 
    void Start()
    {
        _taskcompletionCounter = 0;
        foreach (var task in tasks)
        {
            tasksText.text += $"{task.TaskName}\n";
            task.OnTaskCompleted += CompleteTask;
        }
    }

    private void Update()
    {
        if (_taskcompletionCounter == tasks.Count)
        {
                onAreaTasksComplete?.Invoke();
                Debug.Log("Area Complete! Back Door Open");
        }
    }

    void CompleteTask(TaskSO task)
    {
        description.fontStyle = FontStyles.Strikethrough;
        description.text += $"{task.TaskName} complete.\n";
        description.color = Color.red;
        _taskcompletionCounter++;
    }

    public void AddNewTask(TaskSO task)
    {
        tasks.Add(task);
        tasksText.text += $"{task.TaskName}\n";
        task.OnTaskCompleted += CompleteTask;
    }
}
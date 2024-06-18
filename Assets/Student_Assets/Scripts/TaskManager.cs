using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{

    public List<TaskSo> tasks;


    public void AddTask(TaskSo task)
    {
        tasks.Add(task);
    }

    public void CompleteTask(TaskSo task)
    {
        task.CompleteTask();
    }

    public void CheckTasks()
    {
        foreach (TaskSo task in tasks)
        {
            
        }
    }
}

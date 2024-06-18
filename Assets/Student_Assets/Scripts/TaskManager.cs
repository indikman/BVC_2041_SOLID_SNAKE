using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{

    public List<TaskSo> tasks;
    private AudioSource _sfx;

    private void Start()
    {
        _sfx = GetComponent<AudioSource>();
    }
    public void AddTask(TaskSo task)
    {
        tasks.Add(task);
    }

    public void CompleteTask(TaskSo task)
    {
        task.CompleteTask();
        _sfx.Play();
    }

    public void CheckTasks()
    {
        foreach (TaskSo task in tasks)
        {
            
        }
    }
}

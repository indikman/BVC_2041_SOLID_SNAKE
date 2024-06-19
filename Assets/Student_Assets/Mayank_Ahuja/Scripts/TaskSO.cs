using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "TaskMenu")]

public class TaskSO : ScriptableObject
{
    public bool isCompleted = false;
    public string task;
    public string discription;
    
  

    public Action OnTaskComplete;
    public void CompleteTask()
    {
        isCompleted = true;
        OnTaskComplete?.Invoke();
    }
}



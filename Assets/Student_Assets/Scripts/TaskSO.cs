using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TaskX", menuName = "SOs/Task", order = 3)]

public class TaskSO : ScriptableObject
{
    [field: SerializeField]
    public string TaskText;
    public bool TaskCompleted = false;
    public bool TaskAvailable = false;
    public TaskType TaskType;

    public event Action<TaskSO> TaskComplete;
    public event Action<TaskSO> TaskActivate;
    public void CompleteTask()
    {
        TaskCompleted = true;
        TaskComplete?.Invoke(this);
    }
    public void TaskActive()
    {
        TaskAvailable = true;
        TaskActivate?.Invoke(this);
    }
}
[Serializable]
public enum TaskType
{
    Move, Interact
}

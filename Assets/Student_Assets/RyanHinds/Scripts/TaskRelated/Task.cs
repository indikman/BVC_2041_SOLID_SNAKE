using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "Create/Task")]
public class Task : ScriptableObject
{
    public string TaskName;
    public string Description;
    public bool IsTaskCompleted = false;
    public TaskType Type;

    public event Action<Task> OnTaskCompleted;

    public void CompleteTask()
    {
        IsTaskCompleted = true;
        OnTaskCompleted?.Invoke(this);
    }
}

[Serializable]
public enum TaskType
{
    COLLISION_TRIGGER,
    TIMED_TRIGGER
}

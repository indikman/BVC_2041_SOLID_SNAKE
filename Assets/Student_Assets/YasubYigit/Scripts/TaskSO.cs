using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "SOs/Task")]
public class TaskSO : ScriptableObject
{
    public enum TaskType
    {
        CLICK,
        TRIGGER
    };

    public bool isComplete = false;
    public string name;
    public string description;
    public TaskType type;

    public void OnComplete()
    {
        isComplete = true;
    }
}

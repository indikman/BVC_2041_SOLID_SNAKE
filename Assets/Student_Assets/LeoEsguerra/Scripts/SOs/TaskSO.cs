using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "SOs/Task")]
public class TaskSO : ScriptableObject
{
    public int taskID;
    public bool isComplete = false;
    public string taskName;

    public void CompleteTask()
    {
        isComplete = true;
    }
}

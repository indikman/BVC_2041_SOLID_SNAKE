using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "SOs/Task")]
public class TaskListSO : ScriptableObject
{
    public bool isComplete = false;
    public string taskName;

    public static Action OnTaskComplete;

    private void OnEnable()
    {
        isComplete = false;
    }

    public void CompleteTask()
    {
        Debug.Log("TaskComplete");

        if (isComplete)
        {
            return;
        }

        isComplete = true;
        OnTaskComplete?.Invoke();
    }
}
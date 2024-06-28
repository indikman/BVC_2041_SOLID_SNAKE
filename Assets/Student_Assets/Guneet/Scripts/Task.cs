using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Task", menuName = "Task/Task")]
public class Task : ScriptableObject
{
    public string taskName;
    public bool isCompleted;
    public void CompleteTask()
    {
        isCompleted = true;
        TaskManager.Instance.CheckTasks();
    }
}
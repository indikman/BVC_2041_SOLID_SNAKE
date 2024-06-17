using UnityEngine;
using TMPro;

public class TaskUI : MonoBehaviour
{
    public TaskManager taskManager;
    public TextMeshProUGUI taskText;

    void Update()
    {
        string taskInfo = "";
        foreach (var task in taskManager.Tasks)
        {
            taskInfo += $"Task: {task.TaskName}, Is Complete: {task.IsComplete}\n";
        }
        taskText.text = taskInfo;
    }
}
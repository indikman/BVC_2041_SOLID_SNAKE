using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _tasksText;
    [SerializeField] private Task[] _tasks;

    private void OnEnable()
    {
        foreach (var task in _tasks)
        {
            _tasksText.text = $"\n {task.TaskName}";
            task.OnTaskCompleted += CompelteTask;
        }
    }

    void CompelteTask(Task task)
    {
        _tasksText.fontStyle = FontStyles.Strikethrough;
        _tasksText.color = Color.green;
        _tasksText.text = $"\n {task.TaskName} complete.";
    }
}

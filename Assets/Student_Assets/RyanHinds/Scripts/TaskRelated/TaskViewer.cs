using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TaskViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _tasksText;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private List<Task> _tasks;

    private int _taskCounter = 0;

    public UnityEvent OnAreaTasksComplete;

    private void OnEnable()
    {
        foreach (var task in _tasks)
        {
                _tasksText.text += $"{task.TaskName}\n";
                task.OnTaskCompleted += CompleteTask;
        }
    }

    private void Update()
    {
        if (_taskCounter == _tasks.Count)
        {
            OnAreaTasksComplete?.Invoke();
        }
    }

    void CompleteTask(Task task)
    {
        _description.fontStyle = FontStyles.Strikethrough;
        _description.text += $"{task.TaskName} complete.\n";
        _description.color = Color.green;
        _taskCounter++;
    }

    public void AddNewTask(Task task)
    {
        _tasks.Add(task);
    }
}

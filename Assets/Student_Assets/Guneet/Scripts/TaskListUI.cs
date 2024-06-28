using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskListUI : MonoBehaviour
{
    public TaskManager taskManager;
    public GameObject taskItemPrefab;
    public Transform taskListParent;
    public float itemSpacing = 10f; // Adjust this value for the desired spacing

    private List<GameObject> taskUIItems = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < taskManager.tasks.Count; i++)
        {
            taskManager.tasks[i].isCompleted = false;
        }

        PopulateTaskList();
    }

    private void PopulateTaskList()
    {
        foreach (var task in taskManager.tasks)
        {
            AddTaskToUI(task);
        }
    }

    private void AddTaskToUI(Task task)
    {
        GameObject taskItem = Instantiate(taskItemPrefab, taskListParent);
        taskItem.GetComponentInChildren<Text>().text = task.taskName;
        Toggle taskToggle = taskItem.GetComponentInChildren<Toggle>();
        taskToggle.isOn = task.isCompleted;
        taskUIItems.Add(taskItem);

        // Adjust the position based on the number of items
        RectTransform taskItemRect = taskItem.GetComponent<RectTransform>();
        var anchoredPosition = taskItemRect.anchoredPosition;
        anchoredPosition = new Vector2(anchoredPosition.x, anchoredPosition.y - (taskUIItems.Count * itemSpacing));
        taskItemRect.anchoredPosition = anchoredPosition;
    }
    
    
    public void UpdateTaskUI()
    {
        for (int i = 0; i < taskManager.tasks.Count; i++)
        {
            var task = taskManager.tasks[i];
            var taskItem = taskUIItems[i];
            taskItem.GetComponentInChildren<Toggle>().isOn = task.isCompleted;
        }
    }
}
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;
    public List<Task> tasks = new List<Task>();
    public UnityEvent onAllTasksCompleted;
    public AudioSource completionSound;
    public TaskListUI UI;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CheckTasks();
    }
    public void CompleteTask(Task so)
    {
        if (so != null) so.CompleteTask();
    }
    
    public void CheckTasks()
    {
        UI.UpdateTaskUI();
        foreach (var task in tasks)
        {
            if (!task.isCompleted)
            {
                return;
            }
        }
        onAllTasksCompleted.Invoke();
        PlayCompletionSound();
    }

    private void PlayCompletionSound()
    {
        if (completionSound != null)
        {
            completionSound.Play();
        }
    }
}
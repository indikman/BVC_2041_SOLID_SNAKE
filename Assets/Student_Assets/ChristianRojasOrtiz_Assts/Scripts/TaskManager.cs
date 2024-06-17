using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Task
{
    public string TaskName { get; set; }
    public bool IsComplete { get; set; }
}
public class TaskManager : MonoBehaviour
{
    public List<Task> Tasks = new List<Task>();
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip taskCompleteSound;

    private bool hasPlayedSound = false;

    private void Update()
    {
        if (AreAllTasksComplete() && !hasPlayedSound)
        {
            audioSource.PlayOneShot(taskCompleteSound);
            hasPlayedSound = true;
        }
        //DebugTasks();
    }
   
   private bool AreAllTasksComplete()
   {
       return Tasks.All(task => task.IsComplete);
   }
   
   public void AddTask(string taskName)
   {
       Task newTask = new Task { TaskName = taskName, IsComplete = false };
       Tasks.Add(newTask);
   }
   
   public void CompleteTask(string taskName)
   {
       Task taskToComplete = Tasks.FirstOrDefault(task => task.TaskName == taskName);
       if (taskToComplete != null)
       {
           taskToComplete.IsComplete = true;
       }
   }
   
   public void DebugTasks()
   {
       foreach (Task task in Tasks)
       {
           Debug.Log($"Task: {task.TaskName}, Is Complete: {task.IsComplete}");
       }
   }
}

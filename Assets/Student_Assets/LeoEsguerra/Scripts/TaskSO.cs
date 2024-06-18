using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "SOs/Task")]
public class TaskSO : ScriptableObject
{
    public int taskID;
    public bool isComplete = false;
    public string taskName;
    public AudioClip taskCompleteSound;

    public Action OnTaskComplete;

    private void OnEnable()
    {
        isComplete = false;
    }

    // Mark task as complete
    // Use the AudioSource from TaskTracker to play the sound
    public void CompleteTask()
    {
        if(isComplete)
        {
            return;
        }

        isComplete = true;

        if(taskCompleteSound != null)
        {
            AudioSource.PlayClipAtPoint(taskCompleteSound, Camera.main.transform.position);
        }

        OnTaskComplete?.Invoke();
    }
}

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
    public void CompleteTask(AudioSource soundPlayer)
    {
        isComplete = true;
        if(taskCompleteSound != null)
        {
            soundPlayer.clip = taskCompleteSound;
            soundPlayer.Play();
        }
    }
}

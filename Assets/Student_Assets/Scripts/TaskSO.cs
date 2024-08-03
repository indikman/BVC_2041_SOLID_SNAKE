using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microlight.MicroAudio;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[CreateAssetMenu(fileName = "TaskSO", menuName = "ScriptableObjects/SO", order = 1)]
public class TaskSO : ScriptableObject
{
    /// <summary>
    /// Again, a lot of this was completed by asking Ryan for help. Solution will be very similar with small changes
    /// and comments to show understanding. Apologies.
    /// </summary>
    [SerializeField] public string TaskName;
    [SerializeField] public string TaskDescription;
    public bool TaskCompletionStatus = false;

    [SerializeField] public AudioClip taskcompletesfx;
    // "TaskType" is removed from Ryan's solution not because it isn't a smart idea, it's very smart
    // Just because it's not necessary for this assignment
    
    public event Action<TaskSO> OnTaskCompleted; 
    
    // A public void allows this to be easily accessible
    // Once this void is called, "TaskCompletionStatus" is made true, and the event "OnTaskCompleted" is sent out
    public void CompleteTask()
    {
        Debug.Log("taskcomplete");
        MicroAudio.PlayUISound(taskcompletesfx);
        TaskCompletionStatus = true;
        OnTaskCompleted?.Invoke(this);
    }

    void Start()
    {
        TaskCompletionStatus = false;
    }
    
}
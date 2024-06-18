using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "TaskForPlayerSO", menuName = "PlayerTasks", order = 0)]
public class TasksNeedToBeCompleted : ScriptableObject
{
    //[field:SerializeField]
    //public bool hasTaskBeenCompleted { get; private set; }
    //[field:SerializeField]
    //public AudioSource taskCompleteSoundEffect;

    public delegate void CompletedTask();
    public static event CompletedTask taskCompleted;
    public bool taskIsOver = false; //This bool can change its value from true to false being called on by other scripts

    void OnTaskCompletion()
    {
        if(taskCompleted != null && taskIsOver == true) 
        {
            Debug.Log("Task has been completed");
            taskCompleted(); 
        }
    }
}
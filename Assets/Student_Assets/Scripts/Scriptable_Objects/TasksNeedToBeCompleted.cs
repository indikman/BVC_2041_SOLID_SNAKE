using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "TaskForPlayerSO", menuName = "PlayerTasks", order = 0)]
public class TasksNeedToBeCompleted : ScriptableObject
{
    //[field:SerializeField]
    //public bool hasTaskBeenCompleted { get; private set; }
    //[field:SerializeField]
    //public BoxCollider colliderForTaskCompletion { get; private set; }
    //[field:SerializeField]
    //public AudioSource taskCompleteSoundEffect;

    public delegate void CompletedTask();
    public static event CompletedTask taskCompleted;

    void OnTaskCompletion()
    {
        if(taskCompleted != null)
        {
            //taskCompleteSoundEffect.Play();
            Debug.Log("Task has been completed");
            taskCompleted(); 
            //TaskHasBeenCompleted();
        }
    }

    /*void TaskHasBeenCompleted()
    {
        taskCompleteSoundEffect.Play();
    }*/
}
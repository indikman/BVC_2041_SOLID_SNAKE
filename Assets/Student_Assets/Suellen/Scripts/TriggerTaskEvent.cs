using UnityEngine;
using UnityEngine.Events;

public class TriggerTaskEvent : MonoBehaviour
{
    [SerializeField]
    protected TaskSO task;

    TaskManager _taskManager;

    UnityEvent<int> EventTriggered;
    UnityEvent<int, string> InitialStatusEvent;

    private void Awake()
    {
        _taskManager = FindAnyObjectByType<TaskManager>();

        InitialStatusEvent = new UnityEvent<int,string>();
        EventTriggered = new UnityEvent<int>();

        InitialStatusEvent.AddListener(_taskManager.SetTaskText);
        EventTriggered.AddListener(_taskManager.ChangeTextToCompleted);

        InitialStatusEvent.Invoke(task.index, task.TaskDescription);
    }

    public void OnTaskCompleted()
    {
        if (!task.TaskStatus)
        {
            task.TaskStatus = true;
            EventTriggered.Invoke(task.index);
        }
    }
}

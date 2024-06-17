using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "SOs/Tasks/TaskSO", order = 1)]
public class TaskSO : ScriptableObject
{
    [field: SerializeField]
    public int index;

    [field: SerializeField]
    public string TaskDescription { get; private set; }

    [field: SerializeField]
    public bool TaskStatus { get; set; }

    private void OnEnable()
    {
        TaskStatus = false;
    }
}

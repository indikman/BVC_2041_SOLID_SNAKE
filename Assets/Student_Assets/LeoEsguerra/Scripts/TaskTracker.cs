using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    private int _totalTasks;
    [SerializeField] private List<TaskSO> _tasks;
    // Start is called before the first frame update
    void Start()
    {
        _totalTasks = _tasks.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}

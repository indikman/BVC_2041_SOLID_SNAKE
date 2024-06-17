using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUpdater : MonoBehaviour
{
    [SerializeField] private Task customTask;
    [SerializeField] private float _taskTimer;
    private float _taskTimeStop;

    private void Start()
    {
        _taskTimeStop = _taskTimer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (customTask.IsTaskCompleted) return;

        if (customTask.Type == TaskType.COLLISION_TRIGGER)
        {
            if (other.CompareTag("Player")) { customTask.CompleteTask(); }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (customTask.IsTaskCompleted) return;
        StartTimer();
        if (customTask.Type == TaskType.TIMED_TRIGGER)
        {
            if (other.CompareTag("Player") && _taskTimer <= 0f)
            {
                customTask.CompleteTask();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (customTask.IsTaskCompleted) return;
        
        if (customTask.Type == TaskType.TIMED_TRIGGER)
        {
            if (other.CompareTag("Player") && _taskTimer > 0f)
            {
                StopTimer();
            }
        }
    }

    void StartTimer()
    {
        _taskTimer -= Time.fixedDeltaTime;
    }

    void StopTimer()
    {
        _taskTimer = _taskTimeStop;
    }
}

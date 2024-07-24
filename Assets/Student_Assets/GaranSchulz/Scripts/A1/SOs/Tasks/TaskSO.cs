using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "TaskSO", menuName = "SOs/Garan/TaskSO", order = 0)]
public class TaskSO : ScriptableObject
{
    public event Action IsComplete;
    public bool Completed = false;

    public void TaskComplete() => IsComplete?.Invoke();
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName="SOs/Task")]
public class Task : ScriptableObject
{
    public bool isComplete = false;
    public string name;
    public string description;

    public Action OnCompleteTask;

    public void OnComplete()
    {
        isComplete = true;
        OnCompleteTask?.Invoke();
    }
}

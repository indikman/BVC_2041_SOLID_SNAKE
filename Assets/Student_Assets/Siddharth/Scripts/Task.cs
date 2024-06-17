using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName="SOs/Task")]
public class Task : ScriptableObject
{
    public bool _isComplete = false;
    public string _name;
    public string _description;

    public Action OnCompleteTask;

    public void OnComplete()
    {
        _isComplete = true;
        OnCompleteTask?.Invoke();
    }
}

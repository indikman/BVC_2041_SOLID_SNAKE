using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using System;

[CreateAssetMenu(fileName = "Quest", menuName = "SOs/Clara/Quest", order = 1)]
public class Quest : ScriptableObject
{
    public string taskName;
    //public string taskDescription;
    public bool isCompleted;

    public Action OnTaskComplete;

    private void OnEnable()
    {
        isCompleted = false;
    }
    public void OnComplete()
    {
        Debug.Log("Task Complete:" + taskName );
        isCompleted = true;
        OnTaskComplete?.Invoke();
    }
}
    
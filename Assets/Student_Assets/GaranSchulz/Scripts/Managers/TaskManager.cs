using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private TaskSO[] tasks;
    
    private void Awake()
    {
        for (int i = 0; i < tasks.Length; i++)
        {
            int index = i;
            tasks[index].IsComplete += () => TestFunction(index);
        }
    }

    public void TestFunction(int number)
    {
        Debug.Log("does it work?" + number);
    }
}

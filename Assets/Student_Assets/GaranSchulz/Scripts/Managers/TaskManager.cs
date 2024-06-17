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
        tasks[0].IsComplete += TestFunction;
    }

    public void TestFunction()
    {
        Debug.Log("does it work?");
    }
}

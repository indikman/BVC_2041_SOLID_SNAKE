using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : ScriptableObject
{
    public string taskname;
    public string taskdesc;
    public bool taskcomplete;

    public event Action<Task> OnTaskComplete;

    // Start is called before the first frame update
    public void CompleteTask()
    {
        taskcomplete = true;
        OnTaskComplete?.Invoke(obj: this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

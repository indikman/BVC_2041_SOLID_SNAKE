using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Scriptable Objects/ Player Tasks")]
public class TaskTrackerScriptableObject : ScriptableObject
{
    public bool task_doorentered = false;
    public bool task_completefirstcodec = false;
    public bool task_backrooms = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

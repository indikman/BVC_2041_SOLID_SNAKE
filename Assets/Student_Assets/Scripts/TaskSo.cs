using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "TaskSo", menuName = "SOs/Ayden/TaskSo", order = 1)]
public class TaskSo : ScriptableObject
{
    public string description;
    public bool isCompleted;
    public UnityEvent onTaskCompleted;
    public AudioSource _sfx;

    public void CompleteTask()
    {
        isCompleted = true;
        onTaskCompleted?.Invoke();
        _sfx.Play();

    }

}

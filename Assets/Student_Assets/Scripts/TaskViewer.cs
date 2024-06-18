using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text taskList;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    
    public void TaskDone(GameObject Crossout)
    {
        Crossout.SetActive(true);
        source.PlayOneShot(clip);
    }
    public void AddTask(TaskSO Task)
    {
        taskList.text += $"\n [  ] {Task.TaskText}";
    }

}

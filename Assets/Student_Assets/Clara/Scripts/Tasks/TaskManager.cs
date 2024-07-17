using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{
    public UnityEvent TaskListComplete;
    public IndividualTasks individualTasks;
    //private Quest _quest;
    private TaskUI ui;

    [SerializeField]
    private Quest _quest;

    public AudioSource source;
    public AudioClip clip;

    private void Update()
    {
        foreach (var task in _quest.tasks)
        {
            if (individualTasks.isCompleted == true)
            {
                TaskListComplete?.Invoke();
            }
        }
    }

    public void UpdateTasks()
    {
        source.PlayOneShot(clip);
        ui.UpdateUI();
        // play the audio clip, UI thingz
    }
}
[System.Serializable]
public class IndividualTasks
{
    public string taskName;
    public string taskDescription;
    public bool isCompleted;
}

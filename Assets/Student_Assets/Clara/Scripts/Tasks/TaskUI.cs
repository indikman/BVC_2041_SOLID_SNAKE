using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.PackageManager.Requests;

public class TaskUI : MonoBehaviour
{
    //public IndividualTasks task;
    public Quest quest;

    public TMP_Text taskNameText;
    public TMP_Text taskDescriptionText;

    public void Start()
    {
        UpdateUI();
    }
    public void UpdateUI()
    {
        foreach (var task in quest.tasks)
        {
            taskNameText.text = task.taskName;
            taskDescriptionText.text = task.taskDescription;

            if (task.isCompleted == true)
            {
                Destroy(taskNameText);
                Destroy(taskDescriptionText);
            }
        }
    }
}

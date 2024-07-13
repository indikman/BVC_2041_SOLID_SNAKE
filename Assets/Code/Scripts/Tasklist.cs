using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tasklist : MonoBehaviour
{
    public TextMeshProUGUI tvTask;
    public TaskListSO TVTaskSO;
    public TaskListSO ExitTaskSO;
    private void OnEnable()
    {
        Debug.Log("gaming enabled");

        TaskListSO.OnTaskComplete += UpdateList;
    }

    private void OnDisable()
    {
        TaskListSO.OnTaskComplete -= UpdateList;
    }
    void UpdateList()
    {
        Debug.Log("gaming");
        tvTask.faceColor = new Color32(255, 255, 255, 0);
    }
}
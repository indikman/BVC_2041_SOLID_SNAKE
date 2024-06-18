using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuiManager : MonoBehaviour
{
    public TaskSo task;
    public TextMeshProUGUI text;

    void Start()
    {
        text.text = task.description;
        task.onTaskCompleted.AddListener(UpdateUI);
    }

    void UpdateUI()
    {
        text.text = task.description + " (Completed)";
        text.color = Color.green;
    }
}

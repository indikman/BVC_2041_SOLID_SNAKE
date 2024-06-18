using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuiManager : MonoBehaviour
{
    public TaskSo task;
    public TextMeshProUGUI text;
    public string descriptor;
    private AudioSource _sfx;

    void Start()
    {
        text.text = task.description;
        text.text = descriptor;
        task.onTaskCompleted.AddListener(UpdateUI);
        _sfx = GetComponent<AudioSource>();
    }

    void UpdateUI()
    {
        text.text = task.description + " (Completed)";
        text.color = Color.green;
        _sfx.Play();
    }
}

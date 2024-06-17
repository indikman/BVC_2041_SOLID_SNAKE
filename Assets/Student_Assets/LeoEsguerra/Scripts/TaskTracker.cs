using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class TaskTracker : MonoBehaviour
{
    private int _remainingTasks;
    private int _totalTasks;
    private AudioSource _soundPlayer;
    private UIDocument _uiDocument;
    private Label _label;
    public UnityEvent TaskListComplete;
    [SerializeField] private AudioClip _taskListCompleteSound;
    [SerializeField] private List<TaskSO> _tasks;
    private void Awake()
    {
        _remainingTasks = 0;
        _totalTasks = _tasks.Count;

        _soundPlayer = GetComponent<AudioSource>();
        
        _uiDocument = GetComponent<UIDocument>();
    }

    private void Start()
    {
       InitializeUI();
    }

    private void InitializeUI()
    {
        VisualElement panel = _uiDocument.rootVisualElement.Q<VisualElement>("Panel");
        
        _label = panel.Q<Label>("Label");
        _label.text = "Tasks " + _remainingTasks + "/" + _totalTasks;

        foreach (TaskSO task in _tasks)
        {
            Toggle taskToggle = new Toggle();
            taskToggle.label = "";
            taskToggle.value = false;
            taskToggle.text = " " + task.taskName;
            taskToggle.style.fontSize = 20;
            taskToggle.style.color = Color.white;
            taskToggle.focusable = false;
            taskToggle.name = "Task" + task.taskID;
            panel.Add(taskToggle);
        }
    }

    private void UpdateUI(int id)
    {
        VisualElement panel = _uiDocument.rootVisualElement.Q<VisualElement>("Panel");
        Label label = panel.Q<Label>("Label");
        label.text = "Tasks " + _remainingTasks + "/" + _totalTasks;
    
        Toggle taskToggle = panel.Q<Toggle>("Task" + id);
        taskToggle.value = true;
    }

    public void OnTaskComplete(TaskSO task)
    {
        task.CompleteTask(_soundPlayer);
        _remainingTasks++;

        UpdateUI(task.taskID);

        if(_remainingTasks >= _totalTasks)
        {
            Invoke("OnTaskListComplete", 2.0f);
        }
    }

    public void OnTaskListComplete()
    {
        _soundPlayer.clip = _taskListCompleteSound;
        _soundPlayer.Play();

        _label.text = "Tasks Complete!";
        
        TaskListComplete?.Invoke();
    }
}

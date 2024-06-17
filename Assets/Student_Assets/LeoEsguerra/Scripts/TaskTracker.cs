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
    [SerializeField] private float _taskListCompleteSoundDelay = 2.0f;
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
        
        // Label
        _label = panel.Q<Label>("Label");
        _label.text = "Tasks " + _remainingTasks + "/" + _totalTasks;

        // Task Toggles
        foreach (TaskSO task in _tasks)
        {
            Toggle taskToggle = new Toggle();
            taskToggle.label = "";
            taskToggle.value = false;
            taskToggle.text = " " + task.taskName;
            taskToggle.focusable = false;
            taskToggle.name = "Task" + task.taskID;
            
            panel.Add(taskToggle);
        }
    }

    // Updates the UI everytime a task is completed
    private void UpdateUI(int id)
    {
        VisualElement panel = _uiDocument.rootVisualElement.Q<VisualElement>("Panel");
        Label label = panel.Q<Label>("Label");
        label.text = "Tasks " + _remainingTasks + "/" + _totalTasks;
    
        Toggle taskToggle = panel.Q<Toggle>("Task" + id);
        taskToggle.value = true;
    }

    // Called when a task is completed
    // Checks if all tasks are completed
    public void OnTaskComplete(TaskSO task)
    {
        task.CompleteTask(_soundPlayer);
        _remainingTasks++;

        UpdateUI(task.taskID);

        if(_remainingTasks >= _totalTasks)
        {
            Invoke("OnTaskListComplete", _taskListCompleteSoundDelay);
        }
    }

    // Called when all tasks are completed
    // Update the label and play the task complete sound
    // Call any listener to TaskListComplete event
    public void OnTaskListComplete()
    {
        _soundPlayer.clip = _taskListCompleteSound;
        _soundPlayer.Play();

        _label.text = "Tasks Complete!";
        
        TaskListComplete?.Invoke();
    }
}

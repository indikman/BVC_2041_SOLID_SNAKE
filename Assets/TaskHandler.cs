using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TaskHandler : MonoBehaviour
{
    private int _leftTasks;
    private int _totalTasks;

    [SerializeField] private List<TaskSO> _tasks;
    private UIDocument _uiDocument;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
        VisualElement root = _uiDocument.rootVisualElement;

        foreach(TaskSO task in _tasks)
        {
            Toggle toggle = new Toggle();
            toggle.focusable = false;
            toggle.value = false;
            toggle.label = task.name;
            toggle.name = task.name;
            toggle.style.color = Color.white;
            root.Add(toggle);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CompleteTask(TaskSO task)
    {
        VisualElement root = _uiDocument.rootVisualElement;
        Toggle taskToggle = root.Q<Toggle>(task.name);
        taskToggle.value = true;

    }
}

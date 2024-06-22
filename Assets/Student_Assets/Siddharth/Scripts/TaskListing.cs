using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TaskListing : MonoBehaviour
{

    [SerializeField] private Toggle _toggle;
    public List<Task> tasks;

    public UnityEvent AllTaskComplete;
    private int totalTask;

    private void Awake()
    {
        int i = 1;
        // Initialize your UI
        foreach(Task task in tasks)
        {
            Toggle toggle = Instantiate(_toggle, _toggle.transform.parent);
            toggle.transform.position = _toggle.transform.position;
            toggle.transform.localPosition += new Vector3 (0, -50 * i, 0);
            toggle.isOn = false;
            Text text = toggle.GetComponentInChildren<Text>();
            text.text = task.name;

            task.OnCompleteTask += () => SetTaskComplete(toggle);
            i++;

        }
        totalTask = tasks.Count();

        _toggle.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTaskComplete(Toggle toggle)
    {
        toggle.isOn = true;
        if (--totalTask == 0)
        {
            AllTaskComplete?.Invoke();

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TaskListing : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    public List<Task> tasks;

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
            i++;
        }

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

    void SetTaskComplete(Task task)
    { 
        
        //set toggle.isOn = true;
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class TaskLister : MonoBehaviour
{
    [SerializeField] private List<TaskSO> tasks = new List<TaskSO>();
    [SerializeField] private Toggle togglePrefab;
    [SerializeField]  TMP_Text taskText;
    
    int taskTotal;

    [SerializeField] private int offset = -30; 


    // Start is called before the first frame update
    void Start()
    {
        taskTotal = tasks.Count();


        int i = 0; 
        foreach (TaskSO task in tasks)
        {
            Toggle prefab = Instantiate(togglePrefab, transform);
            prefab.transform.localPosition += new Vector3(0, offset * i++, 0) ;
            Text text = prefab.GetComponentInChildren<Text>();
            text.text = task.discription;
            task.OnTaskComplete += () => UpdateToggle(prefab);
        }
    }

    // Update is called once per frame
    void UpdateToggle(Toggle toggle)
    {
        if (toggle.isOn) return;

        toggle.isOn = true;
        taskTotal--;
        if (taskTotal <= 0)
        {
            taskText.text = "Tasks Done!";
        }
    }
        
    
}

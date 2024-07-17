using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{
    public UnityEvent TaskListComplete;

    public AudioSource source;
    public AudioClip clip;
    public List<Quest> quests;
    public Toggle toggle;
    public GameObject canvas;
    private int totalTasks = 0;

    private void Awake()
    {
        totalTasks = quests.Count;
        float staryingX = -780;
        float startingY = 282;
        int i = 0;

        foreach (Quest quest in quests)
        {
            Toggle taskToggle = Instantiate(toggle, canvas.transform);
            taskToggle.transform.localPosition = new Vector3(staryingX, startingY - i * 40, 0);
            taskToggle.enabled = true;
            taskToggle.isOn = false;
            Text label = taskToggle.GetComponentInChildren<Text>();
            label.text = quest.taskName;

            quest.OnTaskComplete += () => OnTaskCompleteEvent(taskToggle);
            i++;
        }
    }

    private void OnTaskCompleteEvent(Toggle toggle)
    {
        Debug.Log("update list");
        source.PlayOneShot(clip);
        toggle.isOn = true;
    }
}

using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{
    [SerializeField] List<TaskSO> tasks;
    [SerializeField] List<TMP_Text> textTasks;

    UnityEvent TasksCompleted;

    private AudioSource _audioSource;

    private void Awake()
    {
        TasksCompleted = new UnityEvent();
        TasksCompleted.AddListener(this.EndGame);
        _audioSource = GetComponent<AudioSource>();
    }

    public void SetTaskText(int index, string text)
    {
        textTasks[index].text = text;
    }

    public void ChangeTextToCompleted(int index)
    {
        textTasks[index].text += " - completed";
        textTasks[index].color = Color.green;
        CheckTasksCompletion();
    }

    public void CheckTasksCompletion()
    {
        if(tasks.All(t => t.TaskStatus == true))
        {
            TasksCompleted.Invoke();
        }
    }

    public void EndGame()
    {
        Debug.Log("Congratulations!");
        _audioSource.Play();
    }
}

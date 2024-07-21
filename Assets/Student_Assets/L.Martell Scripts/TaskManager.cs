using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public UnityEvent currentTask; 
    public IndividualTask objectTask;
    public PlayerTaskList taskList;
    public TMP_Text taskText;

    public bool objectTaskLink = false; //This line directly connecto the  "Object task" script, the one that makes sure the event triggers.
    
    public bool completedTask = false; 
    
    public AudioSource taskSfx;

    private void Update()
    {
        foreach(var task in taskList.task) 
        {
            objectTask.isTaskComplete = objectTaskLink;

            if (objectTaskLink == true)
            {
                completedTask = true;
                currentTask?.Invoke();
                objectTaskLink = false; //Bool being true caused issues with my SFX, setting it up to false seemed to fix it
                objectTask.isTaskComplete = objectTaskLink;
                taskText.text = string.Format("<s>" + taskText.text + "<s>"); //This particular line makes sure the task (on the list is crossed to let the player know they won't have to perform it again)
            }
        }
    }

    public void UpdateTasks()
    {
        taskSfx.Play();
    }
}

[System.Serializable]
public class IndividualTask
{
    public string taskName;
    public bool isTaskComplete;
}
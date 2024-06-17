using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringShop : MonoBehaviour
{
    [SerializeField] 
    protected TasksNeedToBeCompleted taskNeedToBeCompleted;
    [SerializeField]
    private BoxCollider colliderForTaskCompletion;
    [SerializeField] 
    public AudioSource taskFinishedSFX;

    private bool taskIsDone = false;
    private bool taskFinishedOnce = false;

    void OnEnable()
    {
        TasksNeedToBeCompleted.taskCompleted += PlaySound;
    }

    void OnDisable()
    {
        TasksNeedToBeCompleted.taskCompleted -= PlaySound;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<Collider>().gameObject.CompareTag("Player") && taskFinishedOnce == false)
        {
            taskIsDone = true;
            taskFinishedOnce = true;
            PlaySound();
        }
    }

    void PlaySound()
    {
        if(taskIsDone == true && taskFinishedOnce != false)
        {
           taskFinishedSFX.Play(); 
           Debug.Log("I'm inside the shop");
        }
    }
}

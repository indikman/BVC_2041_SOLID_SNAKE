using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DownstairsEvent : MonoBehaviour
{
    public UnityEvent downstairsTriggered;
    public Transform downloc;
    public GameObject snake;
    private void Awake()
    {
        downstairsTriggered.AddListener(tpdown);    



    }
    void tpdown()
    {
        snake.transform.position = downloc.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Tp Down");
    }
}

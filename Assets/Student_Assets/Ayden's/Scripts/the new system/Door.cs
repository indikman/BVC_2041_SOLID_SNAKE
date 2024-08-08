using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    //private ItemManager _itemManager = new ItemManager();
    [SerializeField] private bool _open;
    [SerializeField] private bool _closed;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 Inital;
    [SerializeField] private Vector3 Target;
    [SerializeField] private bool _running;

    
    private void Start()
    {
        
    }
    

    public void Interact()
    {   
        if(!_running)
        {
            if (_open)
            {
                Debug.Log("close");
                DoorClose();
            }
            else if(!_open)
            {
                Debug.Log("open");
                DoorOpen();
            }
        }
        else
        {
            return;
        }

    }

    public void DoorOpen()
    {
        _running = true;
        StopAllCoroutines();
        StartCoroutine("OpenDoor");
    }

    public void DoorClose()
    {
        _running = true;
        StopAllCoroutines();
        StartCoroutine("CloseDoor");
    }

    IEnumerator OpenDoor()
    {

            for (float t = 0; t < 1; t += Time.deltaTime * speed)
            {
                transform.rotation = Quaternion.Slerp(Quaternion.Euler(Inital), Quaternion.Euler(Target), t);
                yield return null;
            }
            transform.rotation = (Quaternion.Euler(Target)); 
            _open = true;
            _running = false;
    }

    IEnumerator CloseDoor()
    {

        
            for (float t = 0; t < 1; t += Time.deltaTime * speed)
            {
                transform.rotation = Quaternion.Slerp(Quaternion.Euler(Target), Quaternion.Euler(Inital), t);
                yield return null;
            }

            transform.rotation = (Quaternion.Euler(Inital));
            _open = false;
            _running = false;
    }
}


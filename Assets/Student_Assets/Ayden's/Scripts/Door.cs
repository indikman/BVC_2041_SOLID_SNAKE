using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public delegate void Interact();
public class Door : MonoBehaviour
{
    private EventManager eventManager = new EventManager();
    [SerializeField] private bool _open;
    [SerializeField] private bool _closed;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 Inital;
    [SerializeField] private Vector3 Target;

    
    private void Start()
    {
        eventManager.InteractEvent += Interact;
    }

    public void Interact()
    {
        if (_open)
        {
            Debug.Log("close");
            DoorClose();
        }

        if (!_open)
        {
            Debug.Log("open");
            DoorOpen();
        }
    }

    public void DoorOpen()
    {
        //StopAllCoroutines();
        StartCoroutine("OpenDoor");
    }

    public void DoorClose()
    {
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
            _open = true;
    }

    IEnumerator CloseDoor()
    {

        
            for (float t = 0; t < 1; t += Time.deltaTime * speed)
            {
                transform.rotation = Quaternion.Slerp(Quaternion.Euler(Target), Quaternion.Euler(Inital), t);
                yield return null;
            }
            _open = false;
    }
}


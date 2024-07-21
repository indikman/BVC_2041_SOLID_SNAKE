using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotation : MonoBehaviour
{
    [SerializeField]
    private float _rotation = 90f;
    public TaskManager taskManager;

    private Vector3 _startRotation;
    private Vector3 _forward;
    private float _doorSpeed = 2.0f;
    private bool _playerHitsDoor = false;

    void Awake()
    {
        _startRotation = transform.rotation.eulerAngles;
        _forward = transform.right;
    }

    void Update()
    {
        _playerHitsDoor = taskManager.completedTask;

        if (_playerHitsDoor == true)
            StartCoroutine(OpenDoor());

        if (_playerHitsDoor == false)
            StopCoroutine(OpenDoor());
           // StartCoroutine(CloseDoor());
    }

    private IEnumerator OpenDoor()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;

        endRotation = Quaternion.Euler(new Vector3(0f, _startRotation.y + _rotation,0f));

        float time = 0;

        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * _doorSpeed;
        }
        
    }
    
    //In my logic, I thought using a coroutine to close the door would work, but i was wrong....LOL
    //private IEnumerator CloseDoor()
    //{
        //Quaternion startRotation = transform.rotation;
        //Quaternion endRotation;

        //endRotation = Quaternion.Euler(new Vector3(0, 0, 0));

        //float time = 0;

        //while (time < 1) 
        //{
           // transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
           // yield return null;
           // time += Time.deltaTime * _doorSpeed;
       // }

   // }
}

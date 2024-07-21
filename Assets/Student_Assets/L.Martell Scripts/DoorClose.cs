using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
    [SerializeField]
    private float rotationAmount = 90f;

    public TaskManager taskManager; 

    private Vector3 _startRotation;
    private Vector3 forward;

    private float _doorSpeed = 3.0f;
    private bool _playerHitsDoor = false;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        _startRotation = transform.rotation.eulerAngles;
        forward = transform.right;
        StartCoroutine(OpenDoor());
    }

    void Update()
    {
        _playerHitsDoor = taskManager.completedTask;
        
        if(_playerHitsDoor == true)
        {
            StopCoroutine(OpenDoor());
            StartCoroutine(CloseDoor());
        }
    }

    private IEnumerator OpenDoor() 
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;

        endRotation = Quaternion.Euler(new Vector3(0, _startRotation.y + rotationAmount, 0));

        float time = 0;

        while(time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * _doorSpeed;
        }
    }

    private IEnumerator CloseDoor() 
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;

        endRotation = Quaternion.Euler(new Vector3(0, 0, 0));

        float time = 0;

        while(time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * _doorSpeed;
        }
    }
}

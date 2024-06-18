using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterTop_OpenDoor : MonoBehaviour
{
    [SerializeField]
    private float rotationAmount = 270f; //Variable controlling how much you wanna rotate the door

    public TaskManager taskManager; 

    private Vector3 _startRotation;
    private Vector3 forward;

    private float doorSpeed = 3.0f;
    private bool playerWantsToInteractWithDoor = false;

    void Awake()
    {
        _startRotation = transform.rotation.eulerAngles;
        forward = transform.right;
    }

    void Update()
    {
        playerWantsToInteractWithDoor = taskManager.playerHasCompletedTask; //Assigning "playerWantsToInteractWithDoor" to the bool value named "playerHasCompletedTask" in "taskManager"

        if(playerWantsToInteractWithDoor == true)
            StartCoroutine(OpenDoor());
    }

    private IEnumerator OpenDoor()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;

        endRotation = Quaternion.Euler(new Vector3(0, 0, _startRotation.y + rotationAmount));

        float time = 0;

        while(time < 1) //Lerping the door's rotation over "time" 
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * doorSpeed;
        }
    }
}

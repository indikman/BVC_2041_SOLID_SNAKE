using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterDoorMovement : MonoBehaviour
{
   [Header ("Rotation Angles")]
    [SerializeField]
    private float rotationAmount = 270f;
    [SerializeField]
    private float forwardDirection = 0f;

    [Header ("Door Collider Scripts")]
    [SerializeField]
    CounterFrontCollider counterFrontCollider; //"CounterFrontColllider" scirpt
    [SerializeField]
    CounterBackCollider counterBackCollider; //"CounterBackColllider" script

    private Vector3 _startRotation;
    private Vector3 forward;
    private Vector3 playerCurrentPosition;

    private float doorSpeed = 3.0f;
    private float playerNormalizedPosition;

    private bool playerWantsToInteractWithDoor = false;

    void Awake()
    {
        _startRotation = transform.rotation.eulerAngles;
        forward = transform.right;
    }

    void Update()
    {
        if(playerWantsToInteractWithDoor == true)
        {
            playerNormalizedPosition = Vector3.Dot(forward, (playerCurrentPosition - transform.position).normalized);
            StartCoroutine(OpenDoor(playerNormalizedPosition));
            StopCoroutine(CloseDoor());
        }

        if(playerWantsToInteractWithDoor == false)
            StartCoroutine(CloseDoor());
    }

    public void GrabDoorCollision(bool playerHasCollided) //This will be called by the "CounterBackCollider" script and the "CounterFrontCollider" scirpt
    {
        playerWantsToInteractWithDoor = playerHasCollided;
    }

    public void GrabPlayerPosition(Vector3 playerPos) //This will be called by the "CounterBackCollider" script and the "CounterFrontCollider" scirpt
    {
        playerCurrentPosition = new Vector3(playerPos.x, playerPos.y, playerPos.z);
    }

    private IEnumerator OpenDoor(float forwardAmount)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;

        if(forwardAmount >= forwardDirection)
            endRotation = Quaternion.Euler(new Vector3(0, 0, _startRotation.y - rotationAmount));
        else
            endRotation = Quaternion.Euler(new Vector3(0, 0, _startRotation.y + rotationAmount));

        float time = 0;

        while(time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * doorSpeed;
        }
    }

    private IEnumerator CloseDoor()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(_startRotation);  


        float time = 0;

        while(time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * doorSpeed;
        }
    }
}

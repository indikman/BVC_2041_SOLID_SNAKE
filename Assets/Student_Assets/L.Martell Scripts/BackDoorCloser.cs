using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackDoorCloser : MonoBehaviour

{
    [SerializeField] private GameObject door;
    [SerializeField]
    private float rotationAmount = -90f;
    
    private Vector3 _startRotation;
    private Vector3 _backwards;

    private float _doorSpeed = 3.0f;
    private bool _playerHitsDoor = false;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Collider>().gameObject.CompareTag("Player"))
        {
            StartCoroutine(CloseDoor());
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

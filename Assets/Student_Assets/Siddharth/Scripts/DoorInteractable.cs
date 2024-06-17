using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    public Quaternion targetRotation;
    public float rotationSpeed = 2.0f;

    private Quaternion initialRotation;
    private Quaternion tempRotation;

    private float timeCount = 0;
    private bool _isClosed = true;

    protected void Awake()
    {
        initialRotation = transform.rotation;
        tempRotation = initialRotation;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            Debug.Log("Door Hit unlocked");

            //tempRotation = targetRotation;
            //_startRotation = false;
            if (_isClosed)
            {
                transform.DOLocalRotate(new Vector3(-90, 0, -90), 2);
                _isClosed = false;
            }
            else
            {
                transform.DOLocalRotate(new Vector3(-90, 0, 0), 2);
                _isClosed = true;
            }
            
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float followSpeed = 10f;


    private void Start()
    {
        transform.position = target.position;
    }
    void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.LookAt(target);
    }
}

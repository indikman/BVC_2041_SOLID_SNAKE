using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : TaskManager
{

    private float rotationSpeed = 10f;
    private float rotationAngle = 90f;
    private Quaternion OrignalRotation;
    private Quaternion TargetRotation;

    void Start()
    {
        OrignalRotation = transform.rotation;
        TargetRotation = Quaternion.Euler(transform.eulerAngles + Vector3.up * rotationAngle);
    }
    public override void DoTask()
    {
        base.DoTask();
        DoorRotate();
    }
    public void DoorRotate()
    {
        Debug.Log("ABC");
        transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, Time.deltaTime * rotationSpeed);
    }
}         

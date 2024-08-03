using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using DG.Tweening;
using Vector3 = UnityEngine.Vector3;

public class DoorRotation : MonoBehaviour
{
    [SerializeField] private Vector3 openedRotation;

    [SerializeField] private Vector3 closedRotation;
    [SerializeField] private Vector3 originalPosition;

    private float doorSpeed = 2f;
    // Door Opener speed unserialized and changed to 2f to prevent the ability to run outside before the door closes
    // Thank you to Ryan / AngelusNein for assistance.
    // using comments to show understanding and not just copypasting lol
    
    private void Awake()
    {
        //On awake, the door sets its current position into a variable
        originalPosition = transform.position;
        //Honestly unsure why this is here will ask, doesn't seem used
    }

    public void DoorOpener()
    {
        // Door opens by taking the vars and pumping them into DOrotate from DOTWEEN
        transform.DOLocalRotate(openedRotation, doorSpeed, RotateMode.Fast);
    }

    public void DoorCloser()
    {
        // Door closes by tweening to originalposition
        transform.DOLocalRotate(closedRotation, doorSpeed, RotateMode.Fast);
    }
}

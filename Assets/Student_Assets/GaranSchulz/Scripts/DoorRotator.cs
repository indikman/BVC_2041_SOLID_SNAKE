using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotator : MonoBehaviour
{
    [SerializeField] private bool rotatesVertically = false;
    [SerializeField] private float doorMovementAngle = 90f; //technically not necessary, but don't want magic numbers
    private bool _isOpen = false;

    //The following function is public so that in-scene Unity events can access it
    public void RotateDoor()
    {
        float angle = doorMovementAngle;
        if (_isOpen)
            angle = -angle; //if door is open, reverse rotation angle

        if (rotatesVertically) //if door is a vertical door, rotate on z axis - rotate on y axis otherwise
        {
            angle = -angle; //invert angle again so that door rotates up instead of down
            this.transform.Rotate(0f,0f,angle);
        }
        else
            this.transform.Rotate(0f,angle,0f);
        _isOpen = !_isOpen; //flip door status to be open
    }
}

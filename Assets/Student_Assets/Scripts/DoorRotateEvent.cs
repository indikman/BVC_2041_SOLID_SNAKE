using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorRotateEvent : MonoBehaviour
{
    [SerializeField] Vector3 Inital; 
    [SerializeField] Vector3 Target; 
    [SerializeField] float speed; 
    [SerializeField] bool rotate = true; 

    public void Rotate()
    {
        StartCoroutine(RotateFromInitalToTarget());
    }

    IEnumerator RotateFromInitalToTarget()
    {
        while (rotate)
        {
            // Rotate from A to B
            for (float t = 0; t < 1; t += Time.deltaTime * speed)
            {
                transform.rotation = Quaternion.Slerp(Quaternion.Euler(Inital), Quaternion.Euler(Target), t);
                yield return null;
            }

            // Rotate from B to A
            for (float t = 0; t < 1; t += Time.deltaTime * speed)
            {
                transform.rotation = Quaternion.Slerp(Quaternion.Euler(Target), Quaternion.Euler(Inital), t);
                yield return null;
            }

            rotate = false;
        }
    }
}

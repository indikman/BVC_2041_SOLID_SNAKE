using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    private bool doorOpen = false;
    Quaternion doorRotation;
    Quaternion targetRotation;
    float rotateTime = 1.0f;
    

    public void Awake()
    {
        targetRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
    }

    public void cycleDoor()
    {
            
        Debug.Log("door cycle");
        if (doorOpen)
        {
            doorOpen = false;
            CloseEvent();
        }
        else
        {
            doorOpen = true;
            OpenEvent();
        }
            
    }


    public void OpenEvent()
    {
        /*
        doorRotation = transform.rotation;
        targetRotation.Set(transform.rotation.x + 1, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        StartCoroutine(Open());
        */

        gameObject.transform.Rotate(0f, 0f, 90f);
    }

    public void CloseEvent()
    {
        /*
        doorRotation = transform.rotation;
        targetRotation.Set(transform.rotation.x - 1, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        StartCoroutine(Open());
        Debug.Log("close event");
        */
        gameObject.transform.Rotate(0f, 0f, -90f);
    }

    IEnumerator Open()
    {
        
        float i = 0;
        while (i < 1)
        {
            i += Time.deltaTime / rotateTime;
            doorRotation = Quaternion.Lerp(doorRotation, targetRotation, (i / rotateTime));
            transform.rotation = doorRotation;
            yield return null;
        }
        
        transform.rotation = targetRotation;
        yield return null;
    }
}

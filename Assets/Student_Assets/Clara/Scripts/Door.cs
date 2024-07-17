using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpening = false;

    public void OpenDoor()
    {
        if (!isOpening)
        {
            this.gameObject.transform.Rotate(0, 90, 0);
            isOpening = true;
        }
    }
    public void CloseDoor()
    {
        this.gameObject.transform.Rotate(0, 0, 0);
        isOpening = false;
    }
}
